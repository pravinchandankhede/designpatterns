namespace Singleton;

using System;

/// <summary>
/// Singleton class that demonstrates the basic implementation of the Singleton pattern.
/// </summary>
public sealed class Basic
{
    /// <summary>
    /// The instance of the Singleton class.
    /// </summary>
    private static Basic? _instance;
    private static DateTime _creationTime;

    /// <summary>
    /// Private constructor to prevent instantiation.
    /// </summary>
    private Basic()
    {

    }

    /// <summary>
    /// Returns the instance of the Singleton class.
    /// </summary>
    /// <returns>Returns a singleton instance.</returns>
    public static Basic GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Basic();
            _creationTime = DateTime.Now;
        }

        return _instance;
    }

    /// <summary>
    /// Returns a message with the instance and creation time.
    /// </summary>
    /// <returns>Gets a message string</returns>
    public String GetMessage()
    {
        return _instance!.ToString();
    }

    /// <summary>
    /// Returns a string representation of the instance.
    /// </summary>
    /// <returns>This returns a string with a creation datetime and hash code of this instance.</returns>
    public override string ToString()
    {
        return $"Basic instance: {_instance!.GetHashCode()} Creation Time {_creationTime}";
    }
}
