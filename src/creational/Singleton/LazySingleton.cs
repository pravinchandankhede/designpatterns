namespace Singleton;

/// <summary>
/// Demonstrate the usage of Lazy class to create singleton instances of class.
/// </summary>
public sealed class LazySingleton
{
    private static readonly Lazy<LazySingleton> _lazy = new Lazy<LazySingleton>(() => new LazySingleton());
    private static readonly DateTime _creationTime = DateTime.Now;

    private LazySingleton()
    {

    }

    /// <summary>
    /// Return a lazy instance of this class.
    /// </summary>
    public static LazySingleton Instance => _lazy.Value;

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
        return $"Lazy instance: {Instance!.GetHashCode()} Creation Time {_creationTime}";
    }
}
