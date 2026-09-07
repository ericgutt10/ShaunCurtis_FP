using FPLib.ResultMonad;

namespace MainConsole;

public static class DataProvider
{
    public static async Task<Result<double>> GetDataAsync()
    {
        await Task.Delay(2000); // Simulate async data fetching
        return ResultT.Read((double)Random.Shared.Next(2, 100));
    }
}