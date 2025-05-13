using PharmacyApp.Services;
using PharmacyApp.Views;

namespace PharmacyApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register routes explicitly for navigation
        Routing.RegisterRoute("ProductDetailPage", typeof(ProductDetailPage));
        Routing.RegisterRoute("HomePage", typeof(HomePage));
        Routing.RegisterRoute("CategoryPage", typeof(CategoryPage));
        Routing.RegisterRoute("MedicationPage", typeof(MedicationPage));
        Routing.RegisterRoute("CartPage", typeof(CartPage));
        Routing.RegisterRoute("OrderPage", typeof(OrderPage));
    }
}
