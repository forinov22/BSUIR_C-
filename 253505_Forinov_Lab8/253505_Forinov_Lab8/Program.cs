using ClassLib.Entities;
using ClassLib.Services;
using LoremNET;

namespace _253505_Forinov_Lab8;

class Program
{
    static async Task Main(string[] args)
    {
        Random r = new();
        List<Client> collection = new();

        Func<Client, bool> filter = client => client.AccountCreationYear == 2023;
    
        for (int i = 0; i < 100; i++)
        {
            collection.Add(new Client(r.Next(), Lorem.Words(1), r.Next(2010, 2024)));
        }

        StreamService<Client> ss = new(new Semaphore(1, 1));
    
        var progressBar = new Progress<string>(str => Console.Write($"\r{str}"));
        var memoryStream = new MemoryStream();

        var task1 = ss.WriteToStreamAsync(memoryStream, collection, progressBar);
        await Task.Delay(200);
        var task2 = ss.CopyFromStreamAsync(memoryStream, "collection.json", progressBar);
        Task.WaitAll(task1, task2);
        var res = await ss.GetStatisticsAsync("collection.json", filter);
        Console.WriteLine($"\nCount of clients that created account this year: {res}");
    }
}