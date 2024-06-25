using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.ViewModels.Dashboard;
using BAIPetRegMobileApp.Views.Dashboard;
using Microsoft.Extensions.Logging;

namespace BAIPetRegMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Views
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<DashboardPage>();


            //View Models
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<DashboardPageViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
