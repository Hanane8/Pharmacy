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

            // Register services
            builder.Services.AddSingleton<MedicationService>();
            builder.Services.AddSingleton<CartService>();
            builder.Services.AddSingleton<Cart>();
            builder.Services.AddSingleton<EmailService>(sp => new EmailService(
                smtpServer: "smtp.gmail.com", //  SMTP server
                smtpPort: 587, //  SMTP port
                smtpUsername: "kh.hanane2009@gmail.com", //  email
                smtpPassword: "ibtf astm hzix kgmo", //  password
                supplierEmail: "kh.hanane2009@gmail.com" // supplier's email
            ));

            // Register ViewModels
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<CartViewModel>();
            builder.Services.AddTransient<OrderViewModel>();
            builder.Services.AddTransient<CategoryViewModel>();
            builder.Services.AddTransient<MedicationViewModel>();
            builder.Services.AddTransient<ProductDetailViewModel>();

            // Register Views
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<CartPage>();
            builder.Services.AddTransient<OrderPage>();
            builder.Services.AddTransient<CategoryPage>();
            builder.Services.AddTransient<MedicationPage>();
            builder.Services.AddTransient<ProductDetailPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}