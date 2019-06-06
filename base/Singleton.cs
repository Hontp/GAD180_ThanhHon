using System;

public class Singleton<T>  where T : class, new()
{
    /// <summary>
    /// The internal parameter that stores the singleton instance.
    /// </summary>
    private static Lazy<T> instance = new Lazy<T>(() => new T());
    
    /// <summary>
    /// Proteced constructor to prevent additional instances of this class being created.
    /// </summary>
    protected Singleton() { } 

    /// <summary>
    /// Public accessor of the class's singleton instance.
    /// </summary>
    public static T Instance
    {
        get
        {
            return instance.Value;
        }
    }
}
