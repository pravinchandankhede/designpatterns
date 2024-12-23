namespace Singleton;

/// <summary>
/// This class demonstrate creation of singleton instance in a thread safe by using C# language dilect.
/// </summary>
public sealed class ThreadSafeSingleton
{
    /// <summary>
    /// Create a thread safe instance.
    /// </summary>
    private static readonly ThreadSafeSingleton _instance = new ThreadSafeSingleton();
    private static readonly DateTime _creationTime = DateTime.Now;

    /// <summary>
    /// Make the class thread safe by having a static constructor.
    /// </summary>
    static ThreadSafeSingleton()
    {

    }

    private ThreadSafeSingleton()
    {

    }

    /// <summary>
    /// Returns the instance of this class.
    /// </summary>
    public static ThreadSafeSingleton Instance => _instance;

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
        return $"Thread safe instance: {Instance!.GetHashCode()} Creation Time {_creationTime}";
    }
}
