using BAIPetRegMobileApp.ViewModels.Dashboard;

namespace BAIPetRegMobileApp.Views.Dashboard;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}