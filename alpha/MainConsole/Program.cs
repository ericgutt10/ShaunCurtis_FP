using System.Dynamic;

namespace MainConsole;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //Console.WriteLine(doitall(Console.ReadLine()!));
        Console.WriteLine(Console.ReadLine().Containerize.Value);
    }

    static readonly Func<double, double> doubler = value => value + value;

    static readonly Func<string, double> parser = Double.Parse;
    static readonly Func<double, double> squarer = Math.Sqrt;

    static readonly Func<string, double> doitall = x => squarer(doubler(parser(x)));

}
