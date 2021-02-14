namespace EsatCelik.Core.CacheManager
{
    public class CacheConfiguration
    {
        #region Properties
        public string Host { get; set; }

        public int Port { get; set; }

        public string Password { get; set; }

        public long DatabaseId { get; set; }

        public string KeyPrefix { get; set; }
        #endregion
    }
}
