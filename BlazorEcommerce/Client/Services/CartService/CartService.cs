using BlazorEcommerce.Shared.DTO;

namespace BlazorEcommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _htppClient;
        private readonly AuthenticationStateProvider _authStateProvider;

        public CartService(ILocalStorageService localStorageService, HttpClient hhtpClient, AuthenticationStateProvider authStateProvider)
        {
            _localStorageService = localStorageService;
            _htppClient = hhtpClient;
            _authStateProvider = authStateProvider;
        }

        public event Action OnChange;

        public async Task AddToCartAsync(CartItem cartItem)
        {
            if (await IsUserAuthenticated())
            {
                Console.WriteLine("User is authenticated!");
            }
            else
            {
                Console.WriteLine("User is NOT authenticated!");
            }

            List<CartItem> cart = await GetCartItemsAsync();

            var sameItem = cart.Find(x => x.ProductId == cartItem.ProductId && x.ProductTypeId == cartItem.ProductTypeId);

            if (sameItem == null)
            {
                cartItem.Quantity += 1;
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _localStorageService.SetItemAsync("cart", cart);

            await GetCartItemsCount();
        }

        private async Task<bool> IsUserAuthenticated()
        {
            var isAuthenticated = (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;

            return isAuthenticated;
        }

        public async Task<List<CartItem>> GetCartAsync()
        {
            List<CartItem> cart = await GetCartItemsAsync();

            return cart;
        }

        public async Task<List<CartProductResponseDTO>> GetCartProductsAsync()
        {
            var cartItems = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            var response = await _htppClient.PostAsJsonAsync("api/cart/products", cartItems);

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

                await GetCartItemsCount();
            }
        }

        public async Task StoreCartItems(bool emptyLocalCart = false)
        {
            var localCart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

            if (localCart == null)
            {
                return;
            }

            await _htppClient.PostAsJsonAsync("api/cart", localCart);

            if (emptyLocalCart)
            {
                await _localStorageService.RemoveItemAsync("cart");
            }
        }

        public async Task UpdateQuantity(CartProductResponseDTO product)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

            if (cart == null)
            {
                return;
            }
            var cartItem = cart.Find(x => x.ProductId == product.ProductId && x.ProductTypeId == product.ProductTypeId);

            if (cartItem != null)
            {
                cartItem.Quantity = product.Quantity;
                await _localStorageService.SetItemAsync("cart", cart);
            }
        }

        private async Task<List<CartItem>> GetCartItemsAsync()
        {
            await GetCartItemsCount();

            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

            cart ??= new List<CartItem>();

            return cart;
        }

        public async Task GetCartItemsCount()
        {
            if (await IsUserAuthenticated())
            {
                var result = await _htppClient.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
                var count = result.Data;

                await _localStorageService.SetItemAsync<int>("cartItemsCount", count);
            }
            else
            {
                var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

                await _localStorageService.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
            }

            OnChange.Invoke();
        }
    }
}
