using Microsoft.Extensions.Logging;
using PharmacyApp.Services;
using PharmacyApp.Views;
using PharmacyApp.ViewModels;
using CommunityToolkit.Maui;
using PharmacyApp.Models;

namespace PharmacyApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
                .UseMauiCommunityToolkit();

            builder.Services.AddSingleton<MedicationService>();
            builder.Services.AddSingleton<CartService>();
            builder.Services.AddSingleton<Cart>();
            builder.Services.AddSingleton<CartViewModel>();
            builder.Services.AddSingleton<OrderViewModel>();
            builder.Services.AddSingleton<CategoryViewModel>();
            builder.Services.AddSingleton<MedicationViewModel>();
            builder.Services.AddSingleton<ProductDetailViewModel>();

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddSingleton<OrderPage>();
            builder.Services.AddSingleton<CartPage>();
            builder.Services.AddSingleton<ProductDetailPage>();
            builder.Services.AddSingleton<CategoryPage>();
            builder.Services.AddSingleton<MedicationPage>();
            builder.Services.AddTransient<Medication>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}