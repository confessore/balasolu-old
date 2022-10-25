using balasolu.models.abstractions;
using balasolu.models.entries;
using balasolu.services.interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Serilog;

namespace balasolu.ui.components
{
    public partial class TwitterEntries
    {
        [Inject]
        IAtomService? _atomService { get; set; }
        [Inject]
        IJSRuntime? _jsRuntime { get; set; }

        Model model = new();

        class Model
        {
            public ICollection<Entry>? Entries { get; set; }
            public IDictionary<string, string>? Usernames { get; set; }
            public int Page { get; set; } = 1;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            //model.Booths = await _marketService.GetPagedBoothsAsync(1, 10);
            //model.Products = await _marketService.GetPagedProductsAsync(1, 10);
            try
            {
                model.Entries = await _atomService.GetPagedTwitterEntriesAsync(model.Page, 20);
                if (model.Usernames == null)
                    model.Usernames = new Dictionary<string, string>();
                else
                    model.Usernames.Clear();
                foreach (var entry in model.Entries)
                {
                    var id = ((TwitterEntry)entry).AuthorId;
                    if (id != null)
                    {
                        if (!model.Usernames.ContainsKey(id))
                            model.Usernames.Add(id, await _atomService.GetTwitterUsernameFromId(id));
                    }
                }
            }
            catch (Exception e)
            {
                Log.Warning(e.Message);
            }
        }

        async Task GoForwardAsync()
        {
            try
            {
                var page = await _atomService.GetLastTwitterEntryPageNumberAsync();
                if (model.Page != page)
                {
                    model.Page++;
                    model.Entries = await _atomService.GetPagedTwitterEntriesAsync(model.Page, 20);
                    if (model.Usernames == null)
                        model.Usernames = new Dictionary<string, string>();
                    else
                        model.Usernames.Clear();
                    foreach (var entry in model.Entries)
                    {
                        var id = ((TwitterEntry)entry).AuthorId;
                        if (id != null)
                        {
                            if (!model.Usernames.ContainsKey(id))
                                model.Usernames.Add(id, await _atomService.GetTwitterUsernameFromId(id));
                        }
                    }
                    StateHasChanged();
                    await _jsRuntime.InvokeVoidAsync("scrollTopZero");
                }
            }
            catch (Exception e)
            {
                Log.Warning(e.Message);
            }
        }

        async Task GoBackwardAsync()
        {
            try
            {
                if (model.Page != 1)
                {
                    model.Page--;
                    model.Entries = await _atomService.GetPagedTwitterEntriesAsync(model.Page, 20);
                    if (model.Usernames == null)
                        model.Usernames = new Dictionary<string, string>();
                    else
                        model.Usernames.Clear();
                    foreach (var entry in model.Entries)
                    {
                        var id = ((TwitterEntry)entry).AuthorId;
                        if (id != null)
                        {
                            if (!model.Usernames.ContainsKey(id))
                                model.Usernames.Add(id, await _atomService.GetTwitterUsernameFromId(id));
                        }
                    }
                    StateHasChanged();
                    await _jsRuntime.InvokeVoidAsync("scrollTopZero");
                }
            }
            catch (Exception e)
            {
                Log.Warning(e.Message);
            }
        }

        async Task GoToStartAsync()
        {
            try
            {
                if (model.Page != 1)
                {
                    model.Page = 1;
                    model.Entries = await _atomService.GetPagedTwitterEntriesAsync(model.Page, 20);
                    if (model.Usernames == null)
                        model.Usernames = new Dictionary<string, string>();
                    else
                        model.Usernames.Clear();
                    foreach (var entry in model.Entries)
                    {
                        var id = ((TwitterEntry)entry).AuthorId;
                        if (id != null)
                        {
                            if (!model.Usernames.ContainsKey(id))
                                model.Usernames.Add(id, await _atomService.GetTwitterUsernameFromId(id));
                        }
                    }
                    StateHasChanged();
                    await _jsRuntime.InvokeVoidAsync("scrollTopZero");
                }
            }
            catch (Exception e)
            {
                Log.Warning(e.Message);
            }
        }

        async Task GoToEndAsync()
        {
            try
            {
                var page = await _atomService.GetLastTwitterEntryPageNumberAsync();
                if (model.Page != page)
                {
                    model.Page = page;
                    model.Entries = await _atomService.GetPagedTwitterEntriesAsync(model.Page, 20);
                    if (model.Usernames == null)
                        model.Usernames = new Dictionary<string, string>();
                    else
                        model.Usernames.Clear();
                    foreach (var entry in model.Entries)
                    {
                        var id = ((TwitterEntry)entry).AuthorId;
                        if (id != null)
                        {
                            if (!model.Usernames.ContainsKey(id))
                                model.Usernames.Add(id, await _atomService.GetTwitterUsernameFromId(id));
                        }
                    }
                    StateHasChanged();
                    await _jsRuntime.InvokeVoidAsync("scrollTopZero");
                }
            }
            catch (Exception e)
            {
                Log.Warning(e.Message);
            }
        }

        string? GenerateImageSource(string? id) =>
            model.Usernames.TryGetValue(id, out var username) ? 
                $"https://unavatar.io/twitter/{username}" : string.Empty;

        string? GenerateEntryHref(string? id) =>
                $"https://twitter.com/anyuser/status/{id}";

        string itemId(string id) =>
            $"Item{id.Replace("-", string.Empty)}";
    }
}
