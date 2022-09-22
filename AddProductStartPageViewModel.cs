using CommunityToolkit.Mvvm.Input;

namespace UnShellApp
{
    public partial class AddProductStartPageViewModel : BasePageViewModel
    {
        readonly ICommonServices _commonServices;
        readonly IPageNavigator _pageNavigator;
        readonly PartnerModel _partnerModel;
        readonly PartnerLocationModel _partnerLocationModel;

        public AddProductStartPageViewModel(
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

        [RelayCommand]
        void GoToSerialNumberScanPage()
        {
            _pageNavigator.GoToAddProductSerialNumberScanPage(new AddProductContext {  Partner = _partnerModel, PartnerLocation = _partnerLocationModel });
        }

        public IAddProductCancelPopupService CancelPopupService { get; set; }

        [RelayCommand]
        Task Close() => CancelPopupService.OkThen(() => _pageNavigator.GoToCustomerLocationProductsPage(_partnerModel, _partnerLocationModel));
    }
}
