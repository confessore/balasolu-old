using balasolu.models.products;
using balasolu.services.interfaces;
using Microsoft.AspNetCore.Components;

namespace balasolu.ui.components
{
    public partial class BoothAddProduct
    {
        [Inject]
        IMarketService? _marketService { get; set; }

        Model model = new();

        class Model
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? ImageSource { get; set; }
            public decimal Price { get; set; }
        }

        void OnNameChanged(ChangeEventArgs args)
        {
            var value = args.Value != null ? (string)args.Value : string.Empty;
            model.Name = value;
        }

        void OnDescriptionChanged(ChangeEventArgs args)
        {
            var value = args.Value != null ? (string)args.Value : string.Empty;
            model.Description = value;
        }

        void OnImageSourceChanged(ChangeEventArgs args)
        {
            var value = args.Value != null ? (string)args.Value : string.Empty;
            model.ImageSource = value;
        }

        void OnPriceChanged(ChangeEventArgs args)
        {
            var value = args.Value != null ? Convert.ToDecimal(args.Value) : 0;
            model.Price = value;
        }

        async void OnClicked()
        {
            await _marketService!.AddProductToBoothAsync(new DefaultProduct() { Name = model.Name });
        }
    }
}
