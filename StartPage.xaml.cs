namespace UnShellApp;

public partial class StartPage : ContentPage
{
	public StartPage(StartPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }
}