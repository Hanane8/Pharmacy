using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PharmacyApp.Models;
using PharmacyApp.Services;
using PharmacyApp.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PharmacyApp.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        private readonly CartService _cartService;

        public CartViewModel(CartService cartService)
        {
            _cartService = cartService;

            ProceedToCheckoutCommand = new AsyncRelayCommand(ProceedToCheckout);

            IncreaseQuantityCommand = new RelayCommand<CartItem>(IncreaseQuantity);

            DecreaseQuantityCommand = new RelayCommand<CartItem>(DecreaseQuantity);

            _cartService.GetItems().CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(Items));
                OnPropertyChanged(nameof(Total));
            };
        }

        public RelayCommand<CartItem> IncreaseQuantityCommand { get; }

        public RelayCommand<CartItem> DecreaseQuantityCommand { get; }

        public ObservableCollection<CartItem> Items => _cartService.GetItems();

        public decimal Total => _cartService.GetTotal();

        [RelayCommand]
        private void RemoveFromCart(CartItem cartItem)
        {
            _cartService.RemoveFromCart(cartItem);
        }

        private void IncreaseQuantity(CartItem cartItem)
        {
            if (cartItem != null)
            {
                _cartService.UpdateQuantity(cartItem, cartItem.Quantity + 1);
                OnPropertyChanged(nameof(Total)); // Trigger total update
            }
        }

        private void DecreaseQuantity(CartItem cartItem)
        {
            if (cartItem != null && cartItem.Quantity > 1)
            {
                _cartService.UpdateQuantity(cartItem, cartItem.Quantity - 1);
                OnPropertyChanged(nameof(Total)); // Trigger total update
            }
        }

        public IAsyncRelayCommand ProceedToCheckoutCommand { get; }

        private Task ProceedToCheckout()
        {
            return Application.Current.MainPage.Navigation.PushAsync(new OrderPage(_cartService));
        }
    }
}
