using CommunityToolkit.Mvvm.ComponentModel;
using PharmacyApp.Models;
using PharmacyApp.Services;
using PharmacyApp.Views;

namespace PharmacyApp.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        protected readonly CartService CartService;
        protected readonly MedicationService _service; 

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

            CartService.AddToCart(medication, 1); 
            await Shell.Current.DisplayAlert("Medicine Added to the cart", "", "OK");
        }

        public async void ShowDetails(Medication medication)
        {
            if (medication == null) return;

            await Application.Current.MainPage.Navigation.PushAsync(new ProductDetailPage(
                _service,
                medication 
            ));
        }



    }
}
