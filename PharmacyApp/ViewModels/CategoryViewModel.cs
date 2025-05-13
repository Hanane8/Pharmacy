using CommunityToolkit.Mvvm.ComponentModel;
using PharmacyApp.Models;
using PharmacyApp.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PharmacyApp.Views;

namespace PharmacyApp.ViewModels
{
    public partial class CategoryViewModel : BaseViewModel
    {
        private readonly MedicationService _service;
        private readonly CartService _cartService;
        public ObservableCollection<Medication> Medications { get; }

        public ICommand AddToCartCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public CategoryViewModel(MedicationService service, CartService cartService, Category selectedCategory = null)
            : base(cartService)
        {
            _service = service;
            _cartService = cartService;
            Medications = selectedCategory != null
                ? new ObservableCollection<Medication>(_service.GetMedicationsByCategory(selectedCategory.Name))
                : new ObservableCollection<Medication>(_service.Medications);

            AddToCartCommand = new Command<Medication>(AddToCart);
            ShowDetailsCommand = new Command<Medication>(ShowDetails);

        }
    }
}
