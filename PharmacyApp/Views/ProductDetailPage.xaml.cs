using PharmacyApp.Models;
using PharmacyApp.Services;
using PharmacyApp.ViewModels;
using System.Collections.Generic;

namespace PharmacyApp.Views
{
    public partial class ProductDetailPage : ContentPage, IQueryAttributable
    {
        private readonly MedicationService _service;

        public ProductDetailPage(MedicationService service, Medication selectedProduct)
        {
            InitializeComponent();

            // Check if selectedProduct is null and set default values if necessary
            if (selectedProduct == null)
            {
                selectedProduct = new Medication
                {
                    Name = "No product selected",
                    Description = "No details available",
                    Price = 0,
                    Image = "default_image_path" // Replace with your default image
                };
            }

            _service = service;

            // Set BindingContext to the ProductDetailViewModel with the selected product
            BindingContext = new ProductDetailViewModel(_service, selectedProduct);
        }


        // Implement the ApplyQueryAttributes method with IDictionary<string, object> parameter
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Name", out var nameObj) && nameObj is string name)
            {
                // Fetch the medication by name
                var medication = _service.GetMedicationByName(name);
                if (medication != null)
                {
                    // Bind the medication to the ViewModel's SelectedProduct
                    BindingContext = new ProductDetailViewModel(_service, medication);
                }
                else
                {
                    // Handle the case where the medication was not found (optional)
                    Console.WriteLine($"Medication with name {name} not found.");
                }
            }
        }
    }
}
