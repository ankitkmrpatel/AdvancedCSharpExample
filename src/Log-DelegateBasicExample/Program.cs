// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Log log = new();

LogDel LogTextToScreenDel, LogTextToFileDel;

LogTextToScreenDel = new LogDel(log.LogTextToScreen);

LogTextToFileDel = new LogDel(log.LogTextToFile);

LogDel multiLogDel = LogTextToScreenDel + LogTextToFileDel;

Console.WriteLine("Please enter your name");

var name = Console.ReadLine();

LogText(multiLogDel, name);

Console.ReadKey();

static void LogText(LogDel logDel, string text)
{
    logDel(text);
}


delegate void LogDel(string text);

public class Log
{
    public void LogTextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}: {text}");

    }

    public void LogTextToFile(string text)
    {
        using (StreamWriter sw = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}
