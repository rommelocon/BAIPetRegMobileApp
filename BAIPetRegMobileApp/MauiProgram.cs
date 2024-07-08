using BAIPetRegMobileApp;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Views;
using BAIPetRegMobileApp.Handlers;
using BAIPetRegMobileApp.Services;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            // Initialize the .NET MAUI Community Toolkit by adding the below line of code
            .UseMauiCommunityToolkit()
            // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton<IPlatformHttpMessageHandler>(sp =>
        {
#if ANDROID
            return new BAIPetRegMobileApp.Platforms.Android.AndroidHttpMessageHandler();
#else
            return null;
#endif
        });

        builder.Services.AddHttpClient("custom-httpclient", httpClient =>
        {
            var baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7107" : "https://localhost:7107";
            httpClient.BaseAddress = new Uri(baseAddress);
        }).ConfigurePrimaryHttpMessageHandler(() =>
        {
            var platformMessageHandler = builder.Services.BuildServiceProvider().GetRequiredService<IPlatformHttpMessageHandler>();
            return platformMessageHandler.GetHttpMessageHandler();
        });

        // View
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<FinalCheckingPage>();
        builder.Services.AddSingleton<PetRegisterPage>();
        builder.Services.AddSingleton<RegisterPage>();

        // View Models
        builder.Services.AddSingleton<LoginPageViewModel>();

        // Services
        builder.Services.AddSingleton<ClientService>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}