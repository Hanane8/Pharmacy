using PharmacyApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using PharmacyApp.Services;
using CommunityToolkit.Mvvm.Input;

namespace PharmacyApp.ViewModels
{
    public partial class ProductDetailViewModel : ObservableObject
    {
        private Medication _selectedProduct;
        private MedicationService _service;
        private readonly CartService _cartService;

        public Medication SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        public ProductDetailViewModel(MedicationService service, Medication selectedProduct)
        {
            _service = service;
            SelectedProduct = selectedProduct;
        }

        [RelayCommand]
        private async void AddToCart()
        {
            if (SelectedProduct == null) return;

            _cartService.AddToCart(SelectedProduct, 1);

            await Shell.Current.DisplayAlert("Medicine Added", $"{SelectedProduct.Name} has been added to the cart.", "OK");

        }

    }
}
