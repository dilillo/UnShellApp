using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UnShellApp
{
    public partial class AddProductSerialNumberEnterPageViewModel : BasePageViewModel
    {
        readonly ICommonServices _commonServices;
        readonly IPageNavigator _pageNavigator;
        readonly AddProductContext _addProductContext;

        public AddProductSerialNumberEnterPageViewModel(
            ICommonServices commonServices,
            IPageNavigator pageNavigator,
            AddProductContext addProductContext)
        {
            _commonServices = commonServices;
            _pageNavigator = pageNavigator;
            _addProductContext = addProductContext;
        }

        [ObservableProperty]
        string _serialNumber;

        [RelayCommand]
        void GoToSerialNumberSearchPage()
        {
            if (string.IsNullOrEmpty(SerialNumber))
            {
                return;
            }

            _pageNavigator.GoToAddProductSerialNumberSearchPage(_addProductContext, SerialNumber);
        }

        [RelayCommand]
        void Back() =>  _pageNavigator.GoToAddProductSerialNumberScanPage(_addProductContext);

        public IAddProductCancelPopupService CancelPopupService { get; set; }

        [RelayCommand]
        Task Close() => CancelPopupService.OkThen(() => _pageNavigator.GoToCustomerLocationProductsPage(_addProductContext.Partner, _addProductContext.PartnerLocation));
    }
}
