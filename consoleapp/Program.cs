namespace SimpleConfigReader.ConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        IStartupInstance startupInstance = new StartupInstance();
        startupInstance.Run();
    }
}
