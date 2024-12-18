using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Views
{
    public partial class OrderPage : ContentPage
    {
        public OrderPage(CartService cartService)
        {
            InitializeComponent();
            BindingContext = new OrderViewModel(cartService);
        }
    }
}
