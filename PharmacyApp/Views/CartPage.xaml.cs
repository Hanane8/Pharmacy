using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Views
{
    public partial class CartPage : ContentPage
    {
        public CartPage(CartService cartService, EmailService emailService)
        {
            InitializeComponent();
            BindingContext = new CartViewModel(cartService, emailService);
        }
    }
}
