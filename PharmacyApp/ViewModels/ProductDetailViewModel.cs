using PharmacyApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using PharmacyApp.Services;

namespace PharmacyApp.ViewModels
{
    public partial class ProductDetailViewModel : ObservableObject
    {
        private Medication _selectedProduct;
        private MedicationService _service;

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
    }

}
