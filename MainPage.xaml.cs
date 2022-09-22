namespace UnShellApp;

public partial class MainPage : FlyoutPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

	private void Button_Pressed(object sender, EventArgs e)
	{
		IsPresented = true;
	}
}

