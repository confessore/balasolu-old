using balasolu.services.interfaces;
using Microsoft.AspNetCore.Components;

namespace balasolu.ui.components
{
    public partial class BoothComponent
    {
        [Inject]
        IMarketService _marketService { get; set; }

        Model model = new();

        class Model
        {
            public bool AddActive { get; set; }
            public bool ManageActive { get; set; } = true;
            public bool SettingsActive { get; set; }
            public bool IsVendorUser { get; set; }
            public bool BoothExists { get; set; }
        }

        public string? AddClass =>
            model.AddActive ? "nav-link active" : "nav-link";

        public string? ManageClass =>
            model.ManageActive ? "nav-link active" : "nav-link";

        public string? SettingsClass =>
            model.SettingsActive ? "nav-link active" : "nav-link";

        void OnAddClicked()
        {
            if (!model.AddActive)
            {
                model.AddActive = !model.AddActive;
                model.ManageActive = false;
                model.SettingsActive = false;
            }
        }

        void OnManageClicked()
        {
            if (!model.ManageActive)
            {
                model.AddActive = false;
                model.ManageActive = !model.ManageActive;
                model.SettingsActive = false;
            }
        }

        void OnSettingsClicked()
        {
            if (!model.SettingsActive)
            {
                model.AddActive = false;
                model.ManageActive = false;
                model.SettingsActive = !model.SettingsActive;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            model.IsVendorUser = await _marketService.IsVendorUserAsync();
            if (model.IsVendorUser)
                model.BoothExists = await _marketService.BoothExistsAsync();
            await base.OnInitializedAsync();
        }
    }
}
