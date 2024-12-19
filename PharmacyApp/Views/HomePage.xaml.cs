using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Views 
{
    public partial class HomePage : ContentPage
    {
        public HomePage(MedicationService service, CartService cartService)
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(service,cartService );


        }

    }

}
