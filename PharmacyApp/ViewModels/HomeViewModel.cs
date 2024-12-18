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

        public ObservableCollection<Category> Categories => _service.Categories;

        [ObservableProperty]
        private Category selectedCategory;


        public HomeViewModel(MedicationService service)
        {
            _service = service;
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
            var cartService = new CartService(new Cart()); // assuming Cart is a class // or inject it through the constructor
            await App.Current.MainPage.Navigation.PushAsync(new CategoryPage(_service, cartService, SelectedCategory!));
        }

    }
}
