using balasolu.web.models.abstractions;
using System.Threading.Tasks;

namespace balasolu.web.services.interfaces
{
    public interface IUserService
    {
        Task UpdateUserPlatformsAsync(User user);
    }
}
