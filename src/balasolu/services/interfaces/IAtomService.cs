using balasolu.models.abstractions;

namespace balasolu.services.interfaces
{
    public interface IAtomService
    {
        Task UpdateDefaultFeedsAsync();
        Task<ICollection<Entry>> GetAllEntriesAsync();
        Task<ICollection<Entry>> GetPagedEntriesAsync(int page, int items);
        Task<ICollection<Entry>> GetPagedTwitterEntriesAsync(int page, int items);
        Task<ICollection<Entry>> GetPagedDefaultEntriesAsync(int page, int items);
        Task<int> GetLastTwitterEntryPageNumberAsync();
        Task<string> GetTwitterUsernameFromId(string id);
        Task UpdateTwitterFeedsAsync();
    }
}
