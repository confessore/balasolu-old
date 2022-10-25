using balasolu.models.booths;
using balasolu.services.interfaces;
using Microsoft.AspNetCore.Components;

namespace balasolu.ui.components
{
    public partial class BoothEdit
    {
        [Inject]
        IMarketService? _marketService { get; set; }

        Model model = new();

        class Model
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? ImageSource { get; set; }
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

        async void OnClicked()
        {
            var booth = new DefaultBooth()
            {
                Name = model.Name,
                Description = model.Description,
                ImageSource = model.ImageSource
            };
            await _marketService!.AddBoothToUserAsync(booth);
            //await _marketService!.AddBoothToUserAsync(new DefaultProduct() { Name = model.Name });
        }
    }
}
