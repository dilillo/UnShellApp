using CommunityToolkit.Mvvm.Input;

namespace UnShellApp
{
    public partial class AddProductSerialNumberSearchPageViewModel : BasePageViewModel
    {
        readonly ICommonServices _commonServices;
        readonly IPageNavigator _pageNavigator;
        readonly AddProductContext _addProductContext;
        readonly string _serialNumber;

        public AddProductSerialNumberSearchPageViewModel(
            ICommonServices commonServices,
            IPageNavigator pageNavigator,
            AddProductContext addProductContext,
            string serialNumber)
        {
            _commonServices = commonServices;
            _pageNavigator = pageNavigator;
            _addProductContext = addProductContext;
            _serialNumber = serialNumber;
        }

        [RelayCommand]
        async Task Load()
        {
            IsBusy = true;

            var serialNumberInfo = await _commonServices.ConnectedProductsApiClient.GetSerialNumberInfo(_serialNumber);

            if (serialNumberInfo == null)
            {
                _pageNavigator.GoToAddProductNotFoundPage(_addProductContext);
            }
            else
            {
                var partnerLocationProduct = new PartnerLocationProductModel
                {
                    Id = serialNumberInfo.Id,
                    Name = serialNumberInfo.Name,
                    PartnerId = _addProductContext.Partner.Id,
                    PartnerLocationId = _addProductContext.PartnerLocation.Id
                };

                if (serialNumberInfo.IsPrimary)
                {
                    _addProductContext.PrimaryProduct = partnerLocationProduct;
                }
                else
                {
                    _addProductContext.SecondaryProduct = partnerLocationProduct;
                }

                _pageNavigator.GoToAddProductConfirmPage(_addProductContext);
            }

            IsBusy = false;
        }
        public IAddProductCancelPopupService CancelPopupService { get; set; }

        [RelayCommand]
        Task Close() => CancelPopupService.OkThen(() => _pageNavigator.GoToCustomerLocationProductsPage(_addProductContext.Partner, _addProductContext.PartnerLocation));
    }
}
