// See https://aka.ms/new-console-template for more information

using System.Text;
using _253505_Forinov_Lab7.Classlib;

var consoleLock = new object();
var semaphore = new Semaphore(1, 1);

var calc = new Calculation(semaphore);

Calculation.CalculationHandler printMethodDuration = (ts, res) =>
{
    var flag = int.TryParse(Thread.CurrentThread.Name, out var line);
    if (!flag)
        throw new ArgumentException();
    line = (line - 1) * 2 + 1;
    
    lock(consoleLock)
    {
        Console.SetCursorPosition(0, line);
        Console.Write($"\rThread {Thread.CurrentThread.ManagedThreadId} ended with result {res} and lasted {ts}");
    }
};

calc.NotifyEnd += printMethodDuration;

Calculation.ProgressHandler printProgress = percentage =>
{
    lock (consoleLock)
    {
        var flag = int.TryParse(Thread.CurrentThread.Name, out var line);
        if (!flag)
            throw new ArgumentException();
        line = (line - 1) * 2;
        var sb = new StringBuilder();
        sb.Append($"Thread {Thread.CurrentThread.ManagedThreadId}:[");
        for (var i = 0; i < percentage / 2; i++)
            sb.Append("=");
        sb.Append($">]{percentage}%");
        Console.SetCursorPosition(0, line);
        Console.Write($"\r{sb}");
    }
};

calc.NotifyProgressChanged += printProgress;

Thread myThread1 = new Thread(calc.SinIntegral)
{
    Name = "1"
};
Thread myThread2 = new Thread(calc.SinIntegral)
{
    Name = "2"
};

Thread myThread3 = new Thread(calc.SinIntegral)
{
    Name = "3"
};

Thread myThread4 = new Thread(calc.SinIntegral)
{
    Name = "4"
};

Thread myThread5 = new Thread(calc.SinIntegral)
{
    Name = "5"
};

myThread1.Start();
myThread2.Start();
myThread3.Start();
myThread4.Start();
myThread5.Start();
