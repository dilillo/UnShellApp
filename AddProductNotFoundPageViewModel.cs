using CommunityToolkit.Mvvm.Input;

namespace UnShellApp
{
    public partial class AddProductNotFoundPageViewModel : BasePageViewModel
    {
        readonly ICommonServices _commonServices;
        readonly IPageNavigator _pageNavigator;
        readonly AddProductContext _addProductContext;

        public AddProductNotFoundPageViewModel(
            ICommonServices commonServices,
            IPageNavigator pageNavigator,
            AddProductContext addProductContext)
        {
            _commonServices = commonServices;
            _pageNavigator = pageNavigator;
            _addProductContext = addProductContext;
        }

        [RelayCommand]
        void Back() => _pageNavigator.GoToAddProductSerialNumberScanPage(_addProductContext);

        public IAddProductCancelPopupService CancelPopupService { get; set; }

        [RelayCommand]
        Task Close() => CancelPopupService.OkThen(() => _pageNavigator.GoToCustomerLocationProductsPage(_addProductContext.Partner, _addProductContext.PartnerLocation));
    }
}
