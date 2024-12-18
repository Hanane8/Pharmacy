using PharmacyApp.Views;
using PharmacyApp.Services;
namespace PharmacyApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

        }

       
    }
}
