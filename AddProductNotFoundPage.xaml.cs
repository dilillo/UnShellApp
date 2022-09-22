namespace UnShellApp;

public partial class AddProductNotFoundPage : ContentPage
{
	public AddProductNotFoundPage(AddProductNotFoundPageViewModel viewModel)
	{
		InitializeComponent();

        viewModel.CancelPopupService = new AddProductCancelPopupService(this);

        BindingContext = viewModel;
    }
}