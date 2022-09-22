namespace UnShellApp;

public partial class CustomerLocationProductsPage : ContentPage
{
	public CustomerLocationProductsPage(CustomerLocationProductsPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((CustomerLocationProductsPageViewModel)BindingContext).LoadCommand.Execute(null);
    }
}