using BAIPetRegMobileApp;
using CommunityToolkit.Maui;
using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Views;
using BAIPetRegMobileApp.Handlers;
using BAIPetRegMobileApp.Services;
using Microsoft.Extensions.Logging;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                fonts.AddFont("MaterialIconsOutlined-Regular.otf", "MaterialIconsOutlined-Regular");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons-Regular");
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
            var baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";
            var baseAddressDevTunnel = "https://sq428ngv-5001.asse.devtunnels.ms";
            httpClient.BaseAddress = new Uri(baseAddressDevTunnel);
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
        builder.Services.AddSingleton<ProfilePage>();
        builder.Services.AddSingleton<DogBreed>();
        builder.Services.AddSingleton<CatBreed>();
        builder.Services.AddSingleton<PetInformationPage>();
        builder.Services.AddSingleton<EditProfilePage>();
        builder.Services.AddSingleton<TOAPage>();
        builder.Services.AddSingleton<SplashPage>();

        // View Models
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<ProfilePageViewModel>();
        builder.Services.AddSingleton<EditProfilePageViewModel>();
        builder.Services.AddSingleton<PetRegisterPageViewModel>();
        builder.Services.AddSingleton<PetInformationPageViewModel>();

        // Services
        builder.Services.AddSingleton<ClientService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}