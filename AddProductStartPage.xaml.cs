namespace UnShellApp;

public partial class AddProductStartPage : ContentPage
{
	public AddProductStartPage(AddProductStartPageViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}