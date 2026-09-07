/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace FPLib.ResultMonad;

public class ResultException(string message) : Exception(message)
{
    public static ResultException Create(string message) => new(message);
    public static ResultException Null => new("The input value was null");
}