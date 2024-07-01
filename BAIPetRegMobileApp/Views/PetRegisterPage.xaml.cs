using SQLite;

namespace BAIPetRegMobileApp.Views;

public partial class PetRegisterPage : ContentPage
{
 



    public PetRegisterPage()
    {
        InitializeComponent();

    }

   

    private void BtnSubmit_Clicked(object sender, EventArgs e)
    {

     
        // Navigate to the final checking page
        Shell.Current.GoToAsync(nameof(FinalCheckingPage));
    }


  
}
