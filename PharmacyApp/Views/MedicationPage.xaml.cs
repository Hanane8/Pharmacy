using PharmacyApp.Models;
using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Views
{
    public partial class MedicationPage : ContentPage
    {
        public MedicationPage(MedicationService service, string categoryName)
        {
            InitializeComponent();
            BindingContext = new MedicationViewModel(service, categoryName);
        }
    }


}
