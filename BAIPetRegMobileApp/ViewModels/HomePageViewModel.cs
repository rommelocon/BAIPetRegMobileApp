using CommunityToolkit.Mvvm.ComponentModel;

namespace BAIPetRegMobileApp.ViewModels;
public partial class HomePageViewModel : ObservableObject
{
    private string userName;
    public string UserName
    {
        get => userName;
        set => SetProperty(ref userName, value);
    }

    public HomePageViewModel()
    {

    }
}
