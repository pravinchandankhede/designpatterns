namespace Singleton;

/// <summary>
/// This class demonstrates the eager singleton implementation. In this the instance is created during the class creation itself. 
/// </summary>
public sealed class EagerSingleton
{
    /// <summary>
    /// Create
    /// </summary>
    private static readonly EagerSingleton eagerSingleton = new EagerSingleton();
    private static readonly DateTime _creationTime = DateTime.Now;

    private EagerSingleton()
    {

    }

    /// <summary>
    /// Gets the instance
    /// </summary>
    public static EagerSingleton Instance => eagerSingleton;

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
        return $"Eager instance: {Instance!.GetHashCode()} Creation Time {_creationTime}";
    }
}
