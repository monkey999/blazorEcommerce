using Blazored.LocalStorage;

namespace BlazorEcommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorageService;

        public CartService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public event Action OnChange;

        public async Task AddToCartAsync(CartItem cartItem)
        {
            List<CartItem> cart = await GetCartItemsAsync();

            cart.Add(cartItem);

            await _localStorageService.SetItemAsync("cart", cart);

            OnChange.Invoke();
        }

        public async Task<List<CartItem>> GetCartAsync()
        {
            List<CartItem> cart = await GetCartItemsAsync();

            return cart;
        }

        private async Task<List<CartItem>> GetCartItemsAsync()
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

            cart ??= new List<CartItem>();
            return cart;
        }
    }
}
