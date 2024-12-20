using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PharmacyApp.Models;

namespace PharmacyApp.Services
{
    public class CartService
    {
        private readonly Cart _cart;
        public CartService(Cart cart)
        {
            _cart = cart ?? new Cart();
        }

        public void AddToCart(Medication medication, int quantity)
        {
            if (medication == null) throw new ArgumentNullException(nameof(medication));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");

            var existingItem = _cart.Items.FirstOrDefault(c => c.Medication?.Name == medication.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cart.Items.Add(new CartItem { Medication = medication, Quantity = quantity });
            }
        }

        public void RemoveFromCart(CartItem cartItem)
        {
            if (cartItem == null) throw new ArgumentNullException(nameof(cartItem));
            _cart.Items.Remove(cartItem);
        }

        public decimal GetTotal()
        {
            return _cart.Items.Sum(item => item.Total);
        }

        public ObservableCollection<CartItem> GetItems()
        {
            return _cart.Items;
        }
        public void ClearCart()
        {
            _cart.Items.Clear();
        }
        public void UpdateQuantity(CartItem cartItem, int newQuantity)
        {
            if (cartItem == null) throw new ArgumentNullException(nameof(cartItem));
            if (newQuantity <= 0) throw new ArgumentOutOfRangeException(nameof(newQuantity), "Quantity must be greater than zero.");

            cartItem.Quantity = newQuantity; // This triggers the Total recalculation automatically
        }

    }
}
