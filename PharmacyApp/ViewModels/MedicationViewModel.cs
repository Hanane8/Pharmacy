using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using PharmacyApp.Services;
using PharmacyApp.Models;
using System.Windows.Input;
using PharmacyApp.Views;

namespace PharmacyApp.ViewModels
{
    public partial class MedicationViewModel : ObservableObject
    {
        private readonly MedicationService _service;
        private readonly CartService _cartService;


        [ObservableProperty]
        private ObservableCollection<Medication> medications;
        //public RelayCommand<Medication> ShowDetailsCommand { get; private set; }
        private Medication _selectedMedication;
        public Medication SelectedMedication
        {
            get => _selectedMedication;
            set => SetProperty(ref _selectedMedication, value);
        }
        public Command<Medication> ShowDetailsCommand { get; }

        public MedicationViewModel(MedicationService service, string categoryName)
        {
            _service = service;
            Medications = _service.GetMedicationsByCategory(categoryName);
            ShowDetailsCommand = new Command<Medication>(async (selectedProduct) =>
            {
                // Navigate to ProductDetailPage when a product is selected
                await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?selectedProduct={selectedProduct}");
            });
        }

        [RelayCommand]
        private void AddToCart(Medication medication)
        {
            _cartService.AddToCart(medication, 1);
        }
        private async void ShowDetails(Medication medication)
        {

            if (medication == null) return;

            // Debugging utskrift för att se om medication.Id är korrekt
            Console.WriteLine($"Navigating to ProductDetailPage with medicationId: {medication.Name}");

            // Navigera till ProductDetailPage och skicka med läkemedels-ID
            await Shell.Current.GoToAsync($"//ProductDetailPage?id={medication.Name}");
        }

    }

}
