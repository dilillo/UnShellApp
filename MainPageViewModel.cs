using CommunityToolkit.Mvvm.Input;

namespace UnShellApp
{
    public partial class MainPageViewModel : BasePageViewModel
    {
        readonly ICommonServices _commonServices;
        readonly IPageNavigator _pageNavigator;

        public MainPageViewModel(
            ICommonServices commonServices,
            IPageNavigator pageNavigator)
        {
            _commonServices = commonServices;
            _pageNavigator = pageNavigator;
        }

        [RelayCommand]
        async Task SignOut()
        {
            await _commonServices.UserAuthentication.SignOut();

            _pageNavigator.GoToStartPage();
        }

        [RelayCommand]
        void GoToCustomersPage() => _pageNavigator.GoToCustomersPage();

        [RelayCommand]
        void GoToMainPage() => _pageNavigator.GoToMainPage();
    }
}
