using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PharmacyApp.Models;
using PharmacyApp.Services;
using System.Threading.Tasks;

namespace PharmacyApp.ViewModels
{
    public partial class OrderViewModel : ObservableObject
    {
        private readonly CartService _cartService;

        public ObservableCollection<CartItem> Items => _cartService.GetItems();

        public decimal Total => _cartService.GetTotal();

        // Kunduppgifter
        [ObservableProperty]
        private string customerName;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string phone;

        public OrderViewModel(CartService cartService)
        {
            _cartService = cartService;
        }

        // Kommando för att lägga beställning
        [RelayCommand]
        private async Task PlaceOrder()
        {
            // Validera och skicka beställningen (logik kan läggas här)
            if (string.IsNullOrWhiteSpace(CustomerName) || string.IsNullOrWhiteSpace(Address) ||
                string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Phone))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill all fields", "OK");
                return;
            }

            // Skapa orderobjekt
            var order = new Order
            {
                CustomerName = CustomerName,
                Address = Address,
                Email = Email,
                Phone = Phone,
                Items = new ObservableCollection<CartItem>(_cartService.GetItems())
            };

            // Töm kundvagnen efter att beställningen är placerad
            _cartService.ClearCart();

            // Navigera tillbaka eller visa bekräftelse
            await Application.Current.MainPage.DisplayAlert("Success", "Order placed successfully!", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
