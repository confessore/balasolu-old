using balasolu.models.abstractions;
using balasolu.web.contexts;
using balasolu.web.models;
using balasolu.web.services.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace balasolu.web.services
{
    sealed class PostService : IPostService
    {
        readonly IDbContextFactory<DefaultContext> _contextFactory;

        public PostService(
            IDbContextFactory<DefaultContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreatePostAsync(string userId, Item itemFT, Item itemISO)
        {
            var post = new DefaultPost()
            {
                ItemFT = itemFT,
                ItemISO = itemISO
            };
            using var context = _contextFactory.CreateDbContext();
            var user = await context.Users.Include(x => x.Posts).FirstOrDefaultAsync(x => x.Id == userId);
            user.Posts?.Add(post);
            await context.SaveChangesAsync();
        }
    }
}
