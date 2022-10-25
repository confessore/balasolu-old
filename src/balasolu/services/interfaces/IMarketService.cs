using balasolu.models.abstractions;
using PayPalCheckoutSdk.Orders;

namespace balasolu.services.interfaces
{
    public interface IMarketService
    {
        Task AddProductToBoothAsync(Product product);
        Task<bool> BoothExistsAsync();
        Task<bool> IsVendorUserAsync();
        Task AddBoothToUserAsync(Booth booth);
        Task AddProductToCartAsync(Product product);
        Task<Cart> GetCartAsync();
        Task<ICollection<Product>> GetProductsAsync();
        Task<ICollection<Booth>> GetAllBoothsAsync();
        Task<ICollection<Booth>> GetPagedBoothsAsync(int page, int items);
        Task<ICollection<Product>> GetPagedProductsAsync(int page, int items);
        Task<Order> CreateOrderAsync();
        Task<Order> CaptureOrderAsync(string orderId);
    }
}
