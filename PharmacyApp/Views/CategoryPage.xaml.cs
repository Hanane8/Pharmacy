using PharmacyApp.Models;
using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Views
{
    public partial class CategoryPage : ContentPage
{
    private readonly MedicationService _service;
    private readonly CartService _cartService;

    public CategoryPage(MedicationService service, CartService cartService, Category? selectedCategory = null)
    {
        InitializeComponent();

        _service = service;
        _cartService = cartService; // Assign CartService here

        // Pass both services to the ViewModel
        BindingContext = new CategoryViewModel(_service, _cartService, selectedCategory);
    }
}


}

