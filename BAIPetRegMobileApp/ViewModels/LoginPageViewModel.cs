using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAIPetRegMobileApp.Views.Dashboard;
using CommunityToolkit.Mvvm.Input;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        #region Commands
        [RelayCommand]
        async void Login()
        {
            await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
        }
        #endregion
    }
}