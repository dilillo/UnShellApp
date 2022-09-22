using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UnShellApp
{
    public partial class AddProductConfirmPageViewModel : BasePageViewModel
    {
        readonly ICommonServices _commonServices;
        readonly IPageNavigator _pageNavigator;
        readonly AddProductContext _addProductContext;

        public AddProductConfirmPageViewModel(
            ICommonServices commonServices,
            IPageNavigator pageNavigator,
            AddProductContext addProductContext)
        {
            _commonServices = commonServices;
            _pageNavigator = pageNavigator;
            _addProductContext = addProductContext;
        }

        [ObservableProperty]
        string _productName;

        [RelayCommand]
        void Load()
        {
            ProductName = _addProductContext.PrimaryProduct.Name;
        }

        [RelayCommand]
        async Task Confirm()
        {
            IsBusy = true;

            await _commonServices.ConnectedProductsApiClient.CreatePartnerLocationProduct(_addProductContext.PrimaryProduct);

            _pageNavigator.GoToCustomerLocationProductsPage(_addProductContext.Partner, _addProductContext.PartnerLocation);

            IsBusy = false;
        }

        [RelayCommand]
        void Back() => _pageNavigator.GoToAddProductSerialNumberScanPage(_addProductContext);

        public IAddProductCancelPopupService CancelPopupService { get; set; }

        [RelayCommand]
        Task Close() => CancelPopupService.OkThen(() => _pageNavigator.GoToCustomerLocationProductsPage(_addProductContext.Partner, _addProductContext.PartnerLocation));
    }
}
