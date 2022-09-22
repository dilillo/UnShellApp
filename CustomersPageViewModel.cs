using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Linq;

namespace UnShellApp
{
    public partial class CustomersPageViewModel : BasePageViewModel
    {
        readonly ICommonServices _commonServices;
        readonly IPageNavigator _pageNavigator;

        public CustomersPageViewModel(
            ICommonServices commonServices,
            IPageNavigator pageNavigator)
        {
            _commonServices = commonServices;
            _pageNavigator = pageNavigator;
        }

        [ObservableProperty]
        List<PartnerModel> _customers;

        [RelayCommand]
        async Task Load()
        {
            IsBusy = true;

            Customers = await _commonServices.ConnectedProductsApiClient.GetPartners();

            IsBusy = false;
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

        [RelayCommand]
        void GoToCustomerLocationsPage(object customer) => _pageNavigator.GoToCustomerLocationsPage((PartnerModel)customer);
    }
}
