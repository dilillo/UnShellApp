namespace UnShellApp;

public partial class AddProductSerialNumberEnterPage : ContentPage
{
	public AddProductSerialNumberEnterPage(AddProductSerialNumberEnterPageViewModel viewModel)
	{
		InitializeComponent();

        viewModel.CancelPopupService = new AddProductCancelPopupService(this);

        BindingContext = viewModel;
    }
}