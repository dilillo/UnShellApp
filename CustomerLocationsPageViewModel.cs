using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UnShellApp
{
    public partial class CustomerLocationsPageViewModel : BasePageViewModel
    {
        readonly ICommonServices _commonServices;
        readonly IPageNavigator _pageNavigator;
        readonly PartnerModel _partnerModel;

        public CustomerLocationsPageViewModel(
            ICommonServices commonServices,
            IPageNavigator pageNavigator,
            PartnerModel partnerModel)
        {
            _commonServices = commonServices;
            _pageNavigator = pageNavigator;
            _partnerModel = partnerModel;
        }

        [ObservableProperty]
        string _customerName;

        [ObservableProperty]
        List<PartnerLocationModel> _customerLocations = new();

        [RelayCommand]
        async Task Load()
        {
            IsBusy = true;

            CustomerName = _partnerModel.Name;
            CustomerLocations = await _commonServices.ConnectedProductsApiClient.GetPartnerLocations(_partnerModel.Id);

            IsBusy = false;
        }

        [RelayCommand]
        void GoToCustomerLocationProductsPage(PartnerLocationModel partnerLocation) => _pageNavigator.GoToCustomerLocationProductsPage(_partnerModel, partnerLocation);

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
