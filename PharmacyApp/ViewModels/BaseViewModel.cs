using CommunityToolkit.Mvvm.ComponentModel;
using PharmacyApp.Models;
using PharmacyApp.Services;
using PharmacyApp.Views;

namespace PharmacyApp.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        protected readonly CartService CartService;

        protected BaseViewModel(CartService cartService)
        {
            CartService = cartService;
        }

        // Method to add medication to the cart
        public async void AddToCart(Medication medication)
        {
            if (medication == null) return;

            CartService.AddToCart(medication, 1); // Add 1 unit of the medication
            await Shell.Current.DisplayAlert("Läkemedel tillagd till kundvagnen!", "", "OK");
        }

        
        public async void ShowDetails(Medication medication)
        {
            if (medication == null) return;

            await Shell.Current.GoToAsync($"///ProductDetailPage?Name={medication.Name}");
        }


        //public async void ShowDetails(Medication medication)
        //{
        //    if (medication == null) return;

        //    var productDetailPage = new ProductDetailPage(medication);
        //    await Application.Current.MainPage.Navigation.PushAsync(productDetailPage);
        //}


    }
}
