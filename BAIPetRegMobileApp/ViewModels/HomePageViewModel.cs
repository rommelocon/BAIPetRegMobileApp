using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BAIPetRegMobileApp.ViewModels;
public partial class HomePageViewModel : ObservableObject
{
    [RelayCommand]
    public static async Task Logout()
    {
        // Remove user preference
        if (Preferences.ContainsKey(nameof(App.user)))
        {
            Preferences.Remove(nameof(App.user));
        }

        // Navigate to login page
        if (Shell.Current != null)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}
