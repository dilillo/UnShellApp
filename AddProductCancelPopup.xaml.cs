namespace UnShellApp;
using CommunityToolkit.Maui.Views;

public partial class AddProductCancelPopup : Popup
{
	public AddProductCancelPopup()
	{
		InitializeComponent();
    }

	private void No_Tapped(object sender, EventArgs e)
	{
        Close(false);
    }

    private void Yes_Tapped(object sender, EventArgs e)
    {
        Close(true);
    }
}

public interface IAddProductCancelPopupService
{
    Task OkThen(Action action);
}

public class AddProductCancelPopupService : IAddProductCancelPopupService
{
    readonly Page _page;

    public AddProductCancelPopupService(Page page)
    {
        _page = page;
    }

    public async Task OkThen(Action action)
    {
        var result = await _page.ShowPopupAsync(new AddProductCancelPopup());

        if (result == null || (bool)result == false)
        {
            return;
        }

        action();
    }
}

public interface INeedAddProductCancelPopupService
{
    IAddProductCancelPopupService CancelPopupService { get; set; }
}

public class NeedAddCancelPopupServiceBehavior : Behavior<ContentPage>
{
    protected override void OnAttachedTo(ContentPage target)
    {
        target.BindingContextChanged += Target_BindingContextChanged;

        base.OnAttachedTo(target);
    }

    protected override void OnDetachingFrom(ContentPage target)
    {
        target.BindingContextChanged -= Target_BindingContextChanged;

        base.OnDetachingFrom(target);
    }

    private void Target_BindingContextChanged(object sender, EventArgs e)
    {
        var target = sender as ContentPage;

        if (target?.BindingContext is INeedAddProductCancelPopupService viewModel)
        {
            viewModel.CancelPopupService = new AddProductCancelPopupService(target);
        }
    }
}