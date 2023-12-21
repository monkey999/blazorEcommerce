using BlazorEcommerce.Shared.DTO;

namespace BlazorEcommerce.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCartAsync(CartItem cartItem);
        Task<List<CartItem>> GetCartAsync();
        Task<List<CartProductResponseDTO>> GetCartProductsAsync();
        Task RemoveProductFromCart(int productId, int productTypeId);
        Task UpdateQuantity(CartProductResponseDTO product);
        Task StoreCartItems(bool emptyLocalCart);
    }
}
