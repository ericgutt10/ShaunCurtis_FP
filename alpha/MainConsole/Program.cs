using System.Diagnostics.Contracts;
using System.Text;
using FPLib;
using FPLib.ResultMonad;
using FPLib.ResultMonad.Blazr.Monad.Result;

namespace MainConsole;


class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Console.WriteLine(
            await DataProvider.GetDataAsync()
            .MapAsync(Math.Sqrt)
            .MapAsync(value => Math.Round(value,2))
            .WriteAsync(
                success: value => $"",
                failure: exception => $""
            )
        );



        //Console.WriteLine(doitall(Console.ReadLine()!));
        //Console.WriteLine(Console.ReadLine().Containerize.Value);

        //Container.Read(Console.ReadLine).Write(Console.WriteLine);
        //ConsoleReader.ReadLine.Write<string?>(Console.WriteLine);

        // Console.ReadLine()
        //     .Containerize
        //     .Bind(TryParseToDouble)
        //     .Map(Math.Sqrt)
        //     .Map(value => Math.Round(value, 2))
        //     .Write(Console.WriteLine);

            Console.WriteLine("Please enter a value");
            Console.WriteLine("enter q to exit");

        // do
        // {
        //     // var input = Console.ReadLine();
        //     // if (string.IsNullOrWhiteSpace(input))
        //     // {
 
        //     //     continue;
        //     // }
  

        //     //if (double.TryParse(input, out double value))
        //     //{
        //         // var newValue = Math.Sqrt(value);
        //         // newValue = double.Round(newValue,2);

        //         // Console.WriteLine($"Sqrt of {value} is: {newValue}");
        //         Console.WriteLine(
        //             Console.ReadLine()
        //             .ToResultT
        //             .Bind(ParseInputToDouble)
        //             .Map(Math.Sqrt)
        //             .Map(value => Math.Round(value, 2))
        //             .Write(
        //                 success: value => $"The result is: {value}",
        //                 failure: execption => $"An error occured: {execption.Message}")
        //             );

        //     //}
        //     //else
        //     {
        //         Console.WriteLine("Please enter a number");

        //     }
        // }while(true);
    }

    public static Result<double> ParseInputToDouble(string? Value)
    {
        var val = double.TryParse(Value, out double value)
        ? value.ToResultT
        : ResultT.Fail<double>("The value entered was not a number.");
        return val;
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


