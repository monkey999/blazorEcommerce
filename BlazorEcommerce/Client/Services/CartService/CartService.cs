using BlazorEcommerce.Shared.DTO;
using Blazored.LocalStorage;

namespace BlazorEcommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _hhtpClient;

        public CartService(ILocalStorageService localStorageService, HttpClient hhtpClient)
        {
            _localStorageService = localStorageService;
            _hhtpClient = hhtpClient;
        }

        public event Action OnChange;

        public async Task AddToCartAsync(CartItem cartItem)
        {
            List<CartItem> cart = await GetCartItemsAsync();

            var sameItem = cart.Find(x => x.ProductId == cartItem.ProductId && x.ProductTypeId == cartItem.ProductTypeId);

            if (sameItem == null)
            {
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _localStorageService.SetItemAsync("cart", cart);

            OnChange.Invoke();
        }

        public async Task<List<CartItem>> GetCartAsync()
        {
            List<CartItem> cart = await GetCartItemsAsync();

            return cart;
        }

        public async Task<List<CartProductResponseDTO>> GetCartProductsAsync()
        {
            var cartItems = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            var response = await _hhtpClient.PostAsJsonAsync("api/cart/products", cartItems);

            var cartProducts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponseDTO>>>();

            return cartProducts.Data;
        }

        public async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.ProductId == productId && x.ProductTypeId == productTypeId);

            if (cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorageService.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }
        }

        private async Task<List<CartItem>> GetCartItemsAsync()
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

            cart ??= new List<CartItem>();

            return cart;
        }
    }
}
