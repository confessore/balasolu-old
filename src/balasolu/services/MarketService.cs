using balasolu.cartitems;
using balasolu.contexts;
using balasolu.models.abstractions;
using balasolu.models.carts;
using balasolu.models.enums;
using balasolu.models.users;
using balasolu.services.interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using Serilog;
using System.Collections.ObjectModel;

namespace balasolu.services
{
    public class MarketService : IMarketService
    {
        readonly IDbContextFactory<DefaultDbContext> _defaultDbContextFactory;
        readonly AuthenticationStateProvider _authenticationStateProvider;
        readonly ILocalStorageService _localStorageService;
        readonly PayPalHttpClient _paypalHttpClient;

        public MarketService(
            IDbContextFactory<DefaultDbContext> defaultDbContextFactory,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorageService,
            PayPalHttpClient paypalHttpClient)
        {
            _defaultDbContextFactory = defaultDbContextFactory;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorageService = localStorageService;
            _paypalHttpClient = paypalHttpClient;
        }

        async Task<bool> IsAuthenticatedAsync()
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (state.User.Identity != null)
                return state.User.Identity.IsAuthenticated;
            return false;
        }

        public async Task<Cart> GetCartAsync()
        {
            if (await IsAuthenticatedAsync())
            {
                var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
                if (state.User.Identity != null)
                {
                    using var defaultContext = await _defaultDbContextFactory.CreateDbContextAsync();
                    if (defaultContext.Users != null)
                    {
                        var user = await defaultContext.Users
                            .Include(x => x.Cart)
                            .ThenInclude(x => x!.CartItems)
                            .FirstOrDefaultAsync(x => x.UserName == state.User.Identity.Name);
                        if (user != null)
                        {
                            if (user.Cart != null)
                                return user.Cart;
                        }
                    }
                }
                return new DefaultCart();
            }
            else
            {
                var user = await _localStorageService.GetDefaultUserAsync();
                if (user != null && user.Cart != null)
                    return user.Cart;
                return new DefaultCart();
            }
        }

        public async Task<bool> BoothExistsAsync()
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (state.User.Identity != null)
            {
                using var defaultContext = await _defaultDbContextFactory.CreateDbContextAsync();
                if (defaultContext.Users != null)
                {
                    var user = await defaultContext.Users.Include(x => ((VendorUser)x).Booth)
                        .FirstOrDefaultAsync(x => x.UserName == state.User.Identity.Name);
                    if (user != null)
                    {
                        var vendorUser = (VendorUser)user;
                        if (vendorUser.Booth != null)
                            return true;
                    }
                }
            }
            return false;
        }

        public async Task<bool> IsVendorUserAsync()
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (state.User.Identity != null)
            {
                using var defaultContext = await _defaultDbContextFactory.CreateDbContextAsync();
                if (defaultContext.Users != null)
                {
                    var user = await defaultContext.Users.FirstOrDefaultAsync(x => x.UserName == state.User.Identity.Name);
                    if (user != null && user.UserType == UserType.Vendor)
                        return true;
                }
            }
            return false;
        }

        public async Task AddBoothToUserAsync(Booth booth)
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (state.User.Identity != null)
            {
                using var defaultContext = await _defaultDbContextFactory.CreateDbContextAsync();
                if (defaultContext.Users != null)
                {
                    var user = await defaultContext.Users.Include(x => ((VendorUser)x).Booth)
                        .FirstOrDefaultAsync(x => x.UserName == state.User.Identity.Name);
                    if (user != null)
                    {
                        var vendorUser = (VendorUser)user;
                        vendorUser.Booth = booth;
                        await defaultContext.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task AddProductToBoothAsync(Product product)
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (state.User.Identity != null)
            {
                using var defaultContext = await _defaultDbContextFactory.CreateDbContextAsync();
                if (defaultContext.Users != null)
                {
                    var user = await defaultContext.Users
                        .Include(x => ((VendorUser)x).Booth)
                        .ThenInclude(x => x!.Products)
                        .FirstOrDefaultAsync(x => x.UserName == state.User.Identity.Name);
                    if (user != null)
                    {
                        var vendorUser = (VendorUser)user;
                        if (vendorUser.Booth != null)
                        {
                            if (vendorUser.Booth.Products != null)
                            {
                                vendorUser.Booth.Products.Add(product);
                                await defaultContext.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
        }

        public async Task AddProductToCartAsync(Product product)
        {
            if (await IsAuthenticatedAsync())
            {
                var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
                if (state.User.Identity != null)
                {
                    using var defaultContext = await _defaultDbContextFactory.CreateDbContextAsync();
                    if (defaultContext.Users != null)
                    {
                        var user = await defaultContext.Users
                            .Include(x => x.Cart)
                            .ThenInclude(x => x!.CartItems)
                            .FirstOrDefaultAsync(x => x.UserName == state.User.Identity.Name);
                        if (user != null && user.Cart != null)
                            user.Cart = await UpdateProductsAsync(user.Cart, product);
                    }
                }
            }
            else
            {
                var user = await _localStorageService.GetDefaultUserAsync();
                if (user == null)
                    user = new DefaultUser();
                if (user.Cart == null)
                    user.Cart = new DefaultCart();
                user.Cart = await UpdateProductsAsync(user.Cart, product);
                await _localStorageService.SetDefaultUserAsync(user);
            }
        }

        Task<Cart> UpdateProductsAsync(Cart cart, Product product)
        {
            var cartItem = new DefaultCartItem()
            {
                CartItemType = (CartItemType)product.ProductType,
                Product = product,
                Quantity = 1
            };

            if (cart.CartItems != null)
            {
                if (cart.CartItems.Any(x => x.Product?.Id == product.Id))
                {

                }
                else
                {
                    cart.CartItems.Add(cartItem);
                }
            }
            else
                cart.CartItems = new Collection<CartItem> { cartItem };
            return Task.FromResult(cart);
        }

        public async Task<ICollection<Product>> GetProductsAsync()
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (state.User.Identity != null)
            {
                using var defaultContext = await _defaultDbContextFactory.CreateDbContextAsync();
                if (defaultContext.Users != null)
                {
                    var user = await defaultContext.Users
                        .Include(x => ((VendorUser)x).Booth)
                        .ThenInclude(x => x!.Products)
                        .FirstOrDefaultAsync(x => x.UserName == state.User.Identity.Name);
                    if (user != null)
                    {
                        var vendorUser = (VendorUser)user;
                        if (vendorUser.Booth != null)
                        {
                            if (vendorUser.Booth.Products != null)
                                return vendorUser.Booth.Products;
                        }
                    }
                }
            }
            return new Collection<Product>();
        }

        public async Task<ICollection<Booth>> GetAllBoothsAsync()
        {
            using var defaultContext = await _defaultDbContextFactory.CreateDbContextAsync();
            if (defaultContext.Booths != null)
                return defaultContext.Booths.ToArray();
            return new Collection<Booth>();
        }

        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            using var defaultContext = await _defaultDbContextFactory.CreateDbContextAsync();
            if (defaultContext.Products != null)
                return defaultContext.Products.ToArray();
            return new Collection<Product>();
        }

        public async Task<ICollection<Booth>> GetPagedBoothsAsync(int page, int items)
        {
            using var defaultContext = await _defaultDbContextFactory.CreateDbContextAsync();
            if (defaultContext.Booths != null)
                return defaultContext.Booths.Skip((page - 1) * items).Take(items).ToArray();
            return new Collection<Booth>();
        }

        public async Task<ICollection<Product>> GetPagedProductsAsync(int page, int items)
        {
            using var defaultContext = await _defaultDbContextFactory.CreateDbContextAsync();
            if (defaultContext.Products != null)
                return defaultContext.Products.Skip((page - 1) * items).Take(items).ToArray();
            return new Collection<Product>();
        }

        public async Task<Order> CreateOrderAsync()
        {
            // Construct a request object and set desired parameters
            // creates a POST request to /v2/checkout/orders
            var orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new()
                {
                    new()
                    {
                        AmountWithBreakdown = new()
                        {
                            CurrencyCode = "USD",
                            Value = "100.00"
                        }
                    }
                },
                ApplicationContext = new()
                {
                    ReturnUrl = "https://localhost",
                    CancelUrl = "https://localhost"
                }
            };

            // Call API with your client and get a response for your call
            var request = new OrdersCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(orderRequest);
            var response = await _paypalHttpClient.Execute(request);
            var orderResult = response.Result<Order>();
            Log.Information("Links:");
            foreach (var link in orderResult.Links)
                Log.Information("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
            return response.Result<Order>();
        }

        public async Task<Order> CaptureOrderAsync(string orderId)
        {
            var request = new OrdersCaptureRequest(orderId);
            request.Prefer("return=representation");
            request.RequestBody(new OrderActionRequest());
            var response = await _paypalHttpClient.Execute(request);
            return response.Result<Order>();
        }
    }
}
