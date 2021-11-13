using balasolu.web.models.abstractions;
using balasolu.web.services.interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace balasolu.web.services
{
    sealed class UserService : IUserService
    {
        readonly UserManager<User> _userManager;

        public UserService(
            UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task UpdateUserPlatformsAsync(User user)
        {
            await _userManager.UpdateAsync(user);
        }
    }
}
