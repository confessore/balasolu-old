using balasolu.models.abstractions;
using balasolu.services.interfaces;
using Microsoft.AspNetCore.Components;
using Serilog;

namespace balasolu.ui.components
{
    public partial class AtomEntries
    {
        [Inject]
        IAtomService? _atomService { get; set; }

        Model model = new();

        class Model
        {
            public ICollection<Entry>? Entries { get; set; }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            //model.Booths = await _marketService.GetPagedBoothsAsync(1, 10);
            //model.Products = await _marketService.GetPagedProductsAsync(1, 10);
            try
            {
                model.Entries = await _atomService.GetPagedDefaultEntriesAsync(1, 7);
            }
            catch (Exception e)
            {
                Log.Warning(e.Message);
            }
        }

        string itemId(string id) =>
            $"Item{id.Replace("-", string.Empty)}";
    }
}
