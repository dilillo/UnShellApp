namespace UnShellApp;

public partial class App : Application
{
	public App(IPageNavigator pageNavigator)
	{
		InitializeComponent();

        pageNavigator.GoToStartPage();
    }
}
