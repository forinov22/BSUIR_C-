using System.Text;
using System.Text.Json;
using System.Text.Unicode;

namespace ClassLib.Services;

public class StreamService<T>
{
    private static Semaphore _semaphore;

    public StreamService(Semaphore semaphore)
    {
        _semaphore = semaphore;
    }
    
    public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data, IProgress<string> progress)
    {
        _semaphore.WaitOne();
        progress.Report(new string($"Thread {Thread.CurrentThread.ManagedThreadId} started writing"));
        
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true
        };
        
        
        //await JsonSerializer.SerializeAsync(stream, data, options);
        
        await stream.WriteAsync(Encoding.UTF8.GetBytes("[\n"));
        Thread.Sleep(500);
        int amount = 0;
        foreach (var item in data)
        {
            Thread.Sleep(10);
            await JsonSerializer.SerializeAsync(stream, item);
            await stream.WriteAsync(Encoding.UTF8.GetBytes(",\n"));
            amount++;
            progress.Report(new string($"Thread: {Thread.CurrentThread.ManagedThreadId} : {amount * 100 / data.Count()}%"));
        }
        
        await stream.WriteAsync(Encoding.UTF8.GetBytes("]"));
        progress.Report(new string($"Thread {Thread.CurrentThread.ManagedThreadId} finished writing"));
        _semaphore.Release();
    }

    public async Task CopyFromStreamAsync(Stream stream, string fileName, IProgress<string> progress)
    {
        _semaphore.WaitOne();
        progress.Report(new string($"Thread {Thread.CurrentThread.ManagedThreadId} started copying"));

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        stream.Position = 0;
        await using (var fs = File.Open(fileName, FileMode.Create))
        {
            await stream.CopyToAsync(fs);
        }
        
        progress.Report(new string($"Thread {Thread.CurrentThread.ManagedThreadId} finished copying"));
        _semaphore.Release();
    }

    public async Task<int> GetStatisticsAsync(string fileName, Func<T, bool> filter)
    {
        int count = 0;
        
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true
        };
        
        await using (var fs = File.Open(fileName, FileMode.Open))
        {
            var res = await JsonSerializer.DeserializeAsync<T[]>(fs, options);

            if (res == null) throw new ArgumentNullException(nameof(res), "Deserialization result cannot be null.");
            
            foreach (var item in res)
            {
                if (filter(item))
                    count++;
            }
        }

        return count;
    }
}
