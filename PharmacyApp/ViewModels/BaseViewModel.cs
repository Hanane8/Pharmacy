using CommunityToolkit.Mvvm.ComponentModel;
using PharmacyApp.Models;
using PharmacyApp.Services;
using PharmacyApp.Views;

namespace PharmacyApp.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        protected readonly CartService CartService;
        protected readonly MedicationService _service; // Declare the _service field

        protected BaseViewModel(CartService cartService)
        {
            CartService = cartService;
        }

        protected BaseViewModel(CartService cartService, MedicationService service)
        {
            CartService = cartService;
            _service = service;
        }

        // Method to add medication to the cart
        public async void AddToCart(Medication medication)
        {
            if (medication == null) return;

            CartService.AddToCart(medication, 1); // Add 1 unit of the medication
            await Shell.Current.DisplayAlert("Läkemedel tillagd till kundvagnen!", "", "OK");
        }

        // Method to navigate to medication details page
        //public async void ShowDetails(Medication medication)
        //{
        //    if (medication == null) return;

        //    await Shell.Current.GoToAsync($"///ProductDetailPage?Name={medication.Name}");
        //}


        public async void ShowDetails(Medication medication)
        {
            if (medication == null) return;

            // Push the ProductDetailPage onto the navigation stack with the necessary data
            await Application.Current.MainPage.Navigation.PushAsync(new ProductDetailPage(
                _service,
                medication // Pass the selected medication directly to the page
            ));
        }



    }
}
