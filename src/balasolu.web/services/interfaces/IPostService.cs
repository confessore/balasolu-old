using balasolu.models.abstractions;
using System.Threading.Tasks;

namespace balasolu.web.services.interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(string userId, Item itemFT, Item itemISO);
    }
}
