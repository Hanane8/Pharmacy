using PharmacyApp.Services;
using PharmacyApp.Views;

namespace PharmacyApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        //Register routes explicitly for navigation

        //var medicationService = new MedicationService();
        //Routing.RegisterRoute("ProductDetailPage", typeof(ProductDetailPage));

        //Routing.RegisterRoute("HomePage", typeof(Views.HomePage));
        //Routing.RegisterRoute("CategoryPage", typeof(Views.CategoryPage));
        //Routing.RegisterRoute("MedicationPage", typeof(Views.MedicationPage));
        //Routing.RegisterRoute("CartPage", typeof(Views.CartPage));
        //Routing.RegisterRoute("OrderPage", typeof(Views.OrderPage));
    }
}
