namespace TechDemo.Console.Libraries;

public class SingletonLibrary
{
    // Ensure singleton instance is created lazily when needed in thread-safe manner with Lazy<T>
    private static readonly Lazy<SingletonLibrary> lazyInstance = new(() => new SingletonLibrary());
    private readonly Guid _guid;

    public static SingletonLibrary Instance => lazyInstance.Value;

    // Private constructor to prevent instantiation from outside.
    private SingletonLibrary()
    {
        _guid = Guid.NewGuid();
    }
    
    public Guid GetGuid()
    {
        return _guid;
    }
}