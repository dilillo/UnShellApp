namespace UnShellApp;

public partial class CustomersPage : FlyoutPage
{
	public CustomersPage(CustomersPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }

    private void Button_Pressed(object sender, EventArgs e)
    {
        IsPresented = true;
    }
}