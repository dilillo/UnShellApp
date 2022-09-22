namespace UnShellApp;

public partial class AddProductConfirmPage : ContentPage
{
	public AddProductConfirmPage(AddProductConfirmPageViewModel viewModel)
	{
		InitializeComponent();

        viewModel.CancelPopupService = new AddProductCancelPopupService(this);

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((AddProductConfirmPageViewModel)BindingContext).LoadCommand.Execute(null);
    }
}