using System.Collections.ObjectModel;
using PharmacyApp.Models;
using PharmacyApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PharmacyApp.Views;
using System.Threading.Tasks;

namespace PharmacyApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly MedicationService _service;
        private readonly CartService _cartService;

        public ObservableCollection<Category> Categories => _service.Categories;

        [ObservableProperty]
        private Category selectedCategory;


        public HomeViewModel(MedicationService service, CartService cartService)
        {
            _service = service;
            _cartService = cartService;
        }

        partial void OnSelectedCategoryChanged(Category value)
        {
            if (value != null)
            {
                NavigateToCategoryPageCommand.Execute(value);
            }
        }
        [RelayCommand]
        private async Task NavigateToCategoryPage()
        {
                await Application.Current.MainPage.Navigation.PushAsync(new CategoryPage(_service, _cartService, SelectedCategory!));
        }

    }
}
