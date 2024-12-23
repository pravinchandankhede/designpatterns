namespace Singleton;

/// <summary>
/// Creates a singleton instance by using optimized version of Lazy<T>
/// </summary>
public sealed class LazyOptimizedSingleton
{
    /// <summary>
    /// Optimized lazy version
    /// </summary>
    private static readonly Lazy<LazyOptimizedSingleton> _lazyOptimized = new (()=> new LazyOptimizedSingleton());
    private static readonly DateTime _creationTime = DateTime.Now;

    private LazyOptimizedSingleton()
    {

    }

    /// <summary>
    /// Get the lazy instance
    /// </summary>
    public static LazyOptimizedSingleton Instance => _lazyOptimized.Value;

    /// <summary>
    /// Returns a message with the instance and creation time.
    /// </summary>
    /// <returns>Gets a message string</returns>
    public String GetMessage()
    {
        return Instance!.ToString();
    }

    /// <summary>
    /// Returns a string representation of the instance.
    /// </summary>
    /// <returns>This returns a string with a creation datetime and hash code of this instance.</returns>
    public override string ToString()
    {
        return $"Lazy Optimized instance: {Instance!.GetHashCode()} Creation Time {_creationTime}";
    }
}
