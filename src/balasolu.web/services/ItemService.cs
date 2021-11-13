using balasolu.web.contexts;
using balasolu.web.services.interfaces;
using System.Threading.Tasks;

namespace balasolu.web.services
{
    sealed class ItemService : IItemService
    {
        readonly DefaultContext _context;

        public ItemService(
            DefaultContext context)
        {
            _context = context;
        }

        public async Task PopulateDbTableAsync()
        {
            /*_context.Items?.RemoveRange(_context.Items.ToArray());
            await _context.BaseItems!.AddRangeAsync(await RuneItems.GenerateRuneItemsAsync());
            await _context.BaseItems!.AddRangeAsync(UniqueItems.axes);
            await _context.BaseItems?.AddRangeAsync(SetItems.axes)!;
            await _context.BaseItems?.AddRangeAsync(UniqueItems.bows)!;
            await _context.BaseItems?.AddRangeAsync(SetItems.bows)!;
            await _context.SaveChangesAsync();*/
            await Task.Delay(0);
        }
    }
}
