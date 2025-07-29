using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PharmacyApp.Models;
using PharmacyApp.Services;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PharmacyApp.ViewModels
{
    public partial class OrderViewModel : ObservableObject
    {
        private readonly CartService _cartService;
        private readonly EmailService _emailService;

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

        public OrderViewModel(CartService cartService, EmailService emailService)
        {
            _cartService = cartService;
            _emailService = emailService;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                // Basic email validation regex
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            // Remove any non-digit characters for validation
            string digitsOnly = Regex.Replace(phone, @"[^\d]", "");
            // Check if we have between 7 and 15 digits (international standard)
            return digitsOnly.Length >= 7 && digitsOnly.Length <= 15;
        }

        // Kommando för att lägga beställning
        [RelayCommand]
        private async Task PlaceOrder()
        {
            try
            {
                // Validate customer name
                if (string.IsNullOrWhiteSpace(CustomerName))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Please enter your full name", "OK");
                    return;
                }

                // Validate address
                if (string.IsNullOrWhiteSpace(Address))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Please enter your delivery address", "OK");
                    return;
                }

                // Validate email
                if (!IsValidEmail(Email))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid email address", "OK");
                    return;
                }

                // Validate phone
                if (!IsValidPhone(Phone))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid phone number", "OK");
                    return;
                }

                // Validate cart is not empty
                if (Items.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Your cart is empty", "OK");
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

                // Send order to supplier
                await _emailService.SendOrderToSupplier(order);

                // Töm kundvagnen efter att beställningen är placerad
                _cartService.ClearCart();

                // Show success message
                await Application.Current.MainPage.DisplayAlert("Success", "Order placed successfully and supplier has been notified!", "OK");

                // Navigate back to the previous page 
               await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to process order: {ex.Message}", "OK");
            }
        }
    }
}
