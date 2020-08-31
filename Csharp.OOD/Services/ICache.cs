namespace Csharp.OOD.Services
{
    /// <summary>
    /// Interface for the Cache
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Get the cache value from the key
        /// </summary>
        /// <param name="key">The cache key</param>
        public string Get(int key);
        
        /// <summary>
        /// Put the key, value into the cache
        /// </summary>
        /// <param name="key">The cache key</param>
        /// <param name="value">The cache value</param>
        void Put(int key, string value);

    }
}


