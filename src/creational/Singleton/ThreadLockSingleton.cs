namespace Singleton;

using System.Threading;

/// <summary>
/// Demostrate the creation of singleton instance using the double check feature using locking.
/// </summary>
public sealed class ThreadLockSingleton
{
    private static ThreadLockSingleton? instance = null;
    private static readonly Lock _lock = new();
    private static DateTime _creationTime;

    private ThreadLockSingleton()
    {
        
    }

    /// <summary>
    /// Gets a instance fo this class in a thread safe way using double check locking feature.
    /// </summary>
    public static ThreadLockSingleton Instance
    {
        get
        {
            //first check
            if (instance == null)
            {
                //acquire lock
                lock (_lock)
                {
                    //second check
                    if (instance == null)
                    {
                        instance = new ThreadLockSingleton();
                        _creationTime = DateTime.Now;
}
                }
            }

            return instance;
        }
    }

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
        return $"Thread Lock instance: {Instance!.GetHashCode()} Creation Time {_creationTime}";
    }

}