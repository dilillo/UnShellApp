namespace UnShellApp;

public partial class AddProductSerialNumberSearchPage : ContentPage
{
	public AddProductSerialNumberSearchPage(AddProductSerialNumberSearchPageViewModel viewModel)
	{
		InitializeComponent();

        viewModel.CancelPopupService = new AddProductCancelPopupService(this);

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((AddProductSerialNumberSearchPageViewModel)BindingContext).LoadCommand.Execute(null);
    }
}