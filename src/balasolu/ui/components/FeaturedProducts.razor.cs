using balasolu.models.abstractions;
using balasolu.services.interfaces;
using Microsoft.AspNetCore.Components;
using Serilog;

namespace balasolu.ui.components
{
    public partial class FeaturedProducts
    {
        [Inject]
        IMarketService? _marketService { get; set; }

        Model model = new();

        class Model
        {
            public ICollection<Product>? Products { get; set; }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            try
            {
                model.Products = await _marketService.GetPagedProductsAsync(1, 10);
            }
            catch (Exception e)
            {
                Log.Warning(e.Message);
            }
        }
    }
}
