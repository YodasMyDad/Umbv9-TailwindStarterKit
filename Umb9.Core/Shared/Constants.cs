namespace Umb9.Core.Shared
{
    /// <summary>
    /// Class to hold constant values
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Class to hold the cache keys used around the site
        /// </summary>
        public static class CacheKeys
        {
            public const string RootId = "Site.RootId";
            public const int MemoryCacheInMinutes = 60;
        }

        /// <summary>
        /// Class to hold the temp data keys
        /// </summary>
        public static class TempDataKeys
        {
            public const string ContactFormSent = "ContactFormSent";
        }
    }
}