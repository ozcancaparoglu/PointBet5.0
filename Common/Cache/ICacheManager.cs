using System.Threading.Tasks;

namespace Common.Cache
{
    public interface ICacheManager
    {
        #region Memory Cache Methods

        T Set<T>(string key, T t, int time);
        TItem Get<TItem>(string key);
        bool TryGetValue<TItem>(string key, out TItem value);

        #endregion

        #region Redis Cache Methods

        Task SetAsync<TITem>(string key, TITem item, int Time);
        Task<TItem> GetAsync<TItem>(string key);
        bool IsCached(string key);

        #endregion

        #region Common

        void Remove(string key);

        #endregion
    }
}