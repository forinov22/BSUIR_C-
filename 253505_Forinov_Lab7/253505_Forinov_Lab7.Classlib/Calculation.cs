using System.Diagnostics;

namespace _253505_Forinov_Lab7.Classlib;

public class Calculation {
    public delegate void CalculationHandler(TimeSpan elapsedTime, double res);
    public event CalculationHandler? NotifyEnd;
    
    public delegate void ProgressHandler(int percentage);
    public event ProgressHandler? NotifyProgressChanged;

    readonly Semaphore _semaphore;

    public Calculation(Semaphore semaphore)
    {
        _semaphore = semaphore;
    }


    public void SinIntegral()
    {
        _semaphore.WaitOne();
        var sw = new Stopwatch();
        sw.Start();
        double result = 0;
        double percentage = 0;
        const double step = 1e-4;
        for (double i = 0; i <= 1; i += step)
        {
            result += Math.Sin(i) * step;
            for (var j = 0; j < 10000; j++) // imitation of computing
            {
                long k = j;
                k *= k;
            }
            percentage += 1e-2;
            NotifyProgressChanged?.Invoke((int) percentage);
        }
        sw.Stop();
        var ts = sw.Elapsed;
        NotifyEnd?.Invoke(ts, result);
        _semaphore.Release();
    }
}