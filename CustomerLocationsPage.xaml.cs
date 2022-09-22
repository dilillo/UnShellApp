namespace UnShellApp;

public partial class CustomerLocationsPage : FlyoutPage
{
	public CustomerLocationsPage(CustomerLocationsPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((CustomerLocationsPageViewModel)BindingContext).LoadCommand.Execute(null);
    }

    private void Button_Pressed(object sender, EventArgs e)
    {
        IsPresented = true;
    }
}