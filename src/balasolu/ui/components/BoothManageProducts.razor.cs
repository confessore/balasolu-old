using balasolu.contexts;
using balasolu.models.abstractions;
using balasolu.services.interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace balasolu.ui.components
{
    public partial class BoothManageProducts
    {
        [Inject]
        IDbContextFactory<DefaultDbContext>? _defaultDbContextFactory { get; set; }

        [Inject]
        IMarketService? _marketService { get; set; }

        Model model = new();

        class Model
        {
            public ICollection<Product>? Products { get; set; }
        }

        protected override async Task OnInitializedAsync()
        {
            model.Products = await _marketService.GetProductsAsync();
            await base.OnInitializedAsync();
        }
    }
}
