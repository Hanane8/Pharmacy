using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using PharmacyApp.Models;
using PharmacyApp.Views;
using PharmacyApp.Services;

namespace PharmacyApp.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        private readonly CartService _cartService;

        public CartViewModel(CartService cartService)
        {
            _cartService = cartService;

            // Initiera kommandot för ProceedToCheckout
            ProceedToCheckoutCommand = new AsyncRelayCommand(ProceedToCheckout);

            // Prenumerera på ändringar i kundvagnens innehåll
            _cartService.GetItems().CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(Items));
                OnPropertyChanged(nameof(Total));
            };
        }

        // Kundvagnens innehåll
        public ObservableCollection<CartItem> Items => _cartService.GetItems();

        // Beräknar totalkostnaden för kundvagnen
        public decimal Total => _cartService.GetTotal();

        // Kommando för att ta bort en artikel från kundvagnen
        [RelayCommand]
        private void RemoveFromCart(CartItem cartItem)
        {
            _cartService.RemoveFromCart(cartItem);
            // OnPropertyChanged är valfritt här eftersom CollectionChanged hanteras ovan
        }

        // Kommando för att gå vidare till kassasidan
        public IAsyncRelayCommand ProceedToCheckoutCommand { get; }

        private Task ProceedToCheckout()
        {
            // Navigera till OrderPage (kassasidan)
            return Application.Current.MainPage.Navigation.PushAsync(new OrderPage(_cartService));
        }
    }
}
