using CommunityToolkit.Mvvm.Input;

namespace UnShellApp
{
    public partial class StartPageViewModel : BasePageViewModel
    {
        readonly ICommonServices _commonServices;
        readonly IPageNavigator _pageNavigator;

        public StartPageViewModel(
            ICommonServices commonServices,
            IPageNavigator pageNavigator)
        {
            _commonServices = commonServices;
            _pageNavigator = pageNavigator;
        }

        [RelayCommand]
        async Task SignIn() 
        {
            await _commonServices.UserAuthentication.SignIn();

            _pageNavigator.GoToMainPage();
        }
    }
}
