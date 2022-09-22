using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UnShellApp
{
    public partial class CustomerLocationProductsPageViewModel : BasePageViewModel
    {
        readonly ICommonServices _commonServices;
        readonly IPageNavigator _pageNavigator;
        readonly PartnerModel _partnerModel;
        readonly PartnerLocationModel _partnerLocationModel;

        public CustomerLocationProductsPageViewModel(
            ICommonServices commonServices,
            IPageNavigator pageNavigator,
            PartnerModel partnerModel,
            PartnerLocationModel partnerLocationModel)
        {
            _commonServices = commonServices;
            _pageNavigator = pageNavigator;
            _partnerModel = partnerModel;
            _partnerLocationModel = partnerLocationModel;
        }

        [ObservableProperty]
        string _customerName;

        [ObservableProperty]
        string _customerLocationName;

        [ObservableProperty]
        List<PartnerLocationProductModel> _customerLocationProducts = new();

        [RelayCommand]
        async Task Load()
        {
            IsBusy = true;

            CustomerName = _partnerModel.Name;
            CustomerLocationName = _partnerLocationModel.Name;
            CustomerLocationProducts = await _commonServices.ConnectedProductsApiClient.GetPartnerLocationProducts(_partnerModel.Id);

            IsBusy = false;
        }

        [RelayCommand]
        void AddProduct() 
        {
            _pageNavigator.GoToAddProductStartPage(_partnerModel, _partnerLocationModel);
        }

        [RelayCommand]
        void Close() => _pageNavigator.GoToCustomersPage();
    }
}
