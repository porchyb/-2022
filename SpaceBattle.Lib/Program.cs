
namespace SpaceBattle.Lib;

public class Program
{
    public static void Main(string[] args)
    {
        int numberOfThreads= int.Parse(args[0]);
        Console.WriteLine("Server starting");
        IoC.Resolve<ICommand>("Server.StartServer", numberOfThreads).Execute();
        //IoC.Resolve<ICommand>("Thread.StartServerCommand", numberOfThreads).Execute();
        Console.WriteLine("Threads are now running");
        Console.ReadKey();
        Console.WriteLine("Threads are now stopping");
        IoC.Resolve<ICommand>("Server.StopServer").Execute();
        Console.WriteLine("Now server stoped");
    }
}
