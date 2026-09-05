using System.Diagnostics.Contracts;
using FPLib;

namespace MainConsole;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //Console.WriteLine(doitall(Console.ReadLine()!));
        //Console.WriteLine(Console.ReadLine().Containerize.Value);

        //Container.Read(Console.ReadLine).Write(Console.WriteLine);
        //ConsoleReader.ReadLine.Write<string?>(Console.WriteLine);

        Console.ReadLine()
            .Containerize
            .Bind(TryParseToDouble)
            .Map(Math.Sqrt)
            .Map(value => Math.Round(value, 2))
            .Write(Console.WriteLine);


    }

static Container<double> TryParseToDouble(string? value) =>
    double.TryParse(value, out var result)
    ? result.Containerize 
    : (0d).Containerize;

    static readonly Func<double, double> doubler = value => value + value;

    static readonly Func<string, double> parser = Double.Parse;
    static readonly Func<double, double> squarer = Math.Sqrt;

    static readonly Func<string, double> doitall = x => squarer(doubler(parser(x)));

}


