using AndroidX.Lifecycle;

namespace UnShellApp;

public partial class CustomersPage : FlyoutPage
{
	public CustomersPage(CustomersPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((CustomersPageViewModel)BindingContext).LoadCommand.Execute(null);
    }

    private void Button_Pressed(object sender, EventArgs e)
    {
        IsPresented = true;
    }
}