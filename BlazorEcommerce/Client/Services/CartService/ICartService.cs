﻿namespace BlazorEcommerce.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCartAsync(CartItem cartItem);
        Task<List<CartItem>> GetCartAsync();
    }
}
