namespace UnShellApp;

public partial class AddProductStartPage : ContentPage
{
	public AddProductStartPage(AddProductStartPageViewModel viewModel)
	{
		InitializeComponent();

		viewModel.CancelPopupService = new AddProductCancelPopupService(this);

        BindingContext = viewModel;
    }
}