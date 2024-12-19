using CommunityToolkit.Mvvm.ComponentModel;
using PharmacyApp.Models;
using PharmacyApp.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PharmacyApp.Views;

namespace PharmacyApp.ViewModels
{
    public partial class CategoryViewModel : ObservableObject
    {
        private readonly MedicationService _service;
        private readonly CartService _cartService;

        public ObservableCollection<Medication> Medications { get; }

        public RelayCommand<Medication> AddToCartCommand { get; private set; }

       
        public RelayCommand<Medication> ShowDetailsCommand { get; private set; }

        public CategoryViewModel(MedicationService service, CartService cartService, Category? selectedCategory = null)
        {
            _service = service;
            _cartService = cartService; 
            if (selectedCategory != null)
            {
                Medications = new ObservableCollection<Medication>(_service.GetMedicationsByCategory(selectedCategory.Name));
            }
            else
            {
                Medications = new ObservableCollection<Medication>(_service.Medications);
            }

            AddToCartCommand = new RelayCommand<Medication>(AddToCart);
            ShowDetailsCommand = new RelayCommand<Medication>(ShowDetails);
        }


        private async void AddToCart(Medication medication)
        {
            if (medication == null) return;

            _cartService.AddToCart(medication, 1);
            await Shell.Current.DisplayAlert("Läkemedel tillagd till kundvagnen!", "", "OK");

            //await Shell.Current.GoToAsync("//CartPage", new Dictionary<string, object> { { "service", _service } });
        }

        private async void ShowDetails(Medication medication)
        {
            if (medication == null) return;

            Console.WriteLine($"Navigating to ProductDetailPage with medicationName: {medication.Name}");

            await Shell.Current.GoToAsync($"//ProductDetailPage?Name={medication.Name}");
        }

        private async void NavigateToDetails(Medication selectedMedication)
        {
            if (selectedMedication != null)
            {
                await Shell.Current.GoToAsync(nameof(ProductDetailPage), new Dictionary<string, object>
        {
            { "SelectedMedication", selectedMedication }
        });
            }
        }


    }
}
