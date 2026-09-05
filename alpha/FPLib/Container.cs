namespace FPLib;

public record Container<T>
{
    public T Value { get; private init; }

    private Container(T value) => this.Value = value;

    public static Container<T> Read(T value) => new(value);
}

public static class Container
{
    public static Container<T> Read<T>(Func<T> func) => Container<T>.Read(func.Invoke());

    extension<T>(T @this)
    {
        public Container<T> Containerize => Container<T>.Read(@this);
    }
}

public static class ContainerFunctionExtensions
{
    extension<T>(Container<T> @this)
    {
        public Container<TResult> Map<TResult>(Func<T, TResult> func)
            => Container<TResult>.Read(func.Invoke(@this.Value));
        
        public Container<TResult> Bind<TResult>(Func<T, Container<TResult>> func)
            => func.Invoke(@this.Value);

        public void Write(Action<T> action) => action.Invoke(@this.Value);
    }
}
