namespace UnShellApp
{
    public interface IPageNavigator
    {
        void GoToAddProductNotFoundPage(AddProductContext addProductContext);

        void GoToAddProductConfirmPage(AddProductContext addProductContext);

        void GoToAddProductSerialNumberSearchPage(AddProductContext addProductContext, string serialNumber);

        void GoToAddProductSerialNumberEnterPage(AddProductContext addProductContext);

        void GoToAddProductSerialNumberScanPage(AddProductContext addProductContext);

        void GoToAddProductStartPage(PartnerModel partner, PartnerLocationModel partnerLocation);

        void GoToCustomerLocationProductsPage(PartnerModel partner, PartnerLocationModel partnerLocation);

        void GoToCustomerLocationsPage(PartnerModel partner);

        void GoToCustomersPage();

        void GoToMainPage();

        void GoToStartPage();
    }

    public class PageNavigator : IPageNavigator
    {
        readonly ICommonServices _commonServices;

        public PageNavigator(ICommonServices commonServices)
        {
            _commonServices = commonServices;
        }

        public void GoToAddProductNotFoundPage(AddProductContext addProductContext) => GoToPage(new AddProductNotFoundPage(new AddProductNotFoundPageViewModel(_commonServices, this, addProductContext)));

        public void GoToAddProductConfirmPage(AddProductContext addProductContext) => GoToPage(new AddProductConfirmPage(new AddProductConfirmPageViewModel(_commonServices, this, addProductContext)));

        public void GoToAddProductSerialNumberSearchPage(AddProductContext addProductContext, string serialNumber) => GoToPage(new AddProductSerialNumberSearchPage(new AddProductSerialNumberSearchPageViewModel(_commonServices, this, addProductContext, serialNumber)));
        
        public void GoToAddProductSerialNumberEnterPage(AddProductContext addProductContext) => GoToPage(new AddProductSerialNumberEnterPage(new AddProductSerialNumberEnterPageViewModel(_commonServices, this, addProductContext)));

        public void GoToAddProductSerialNumberScanPage(AddProductContext addProductContext) => GoToPage(new AddProductSerialNumberScanPage(new AddProductSerialNumberScanPageViewModel(_commonServices, this, addProductContext)));

        public void GoToAddProductStartPage(PartnerModel partner, PartnerLocationModel partnerLocation) => GoToPage(new AddProductStartPage(new AddProductStartPageViewModel(_commonServices, this, partner, partnerLocation)));

        public void GoToCustomerLocationProductsPage(PartnerModel partner, PartnerLocationModel partnerLocation) => GoToPage(new CustomerLocationProductsPage(new CustomerLocationProductsPageViewModel(_commonServices, this, partner, partnerLocation)));

        public void GoToCustomerLocationsPage(PartnerModel partner) => GoToPage(new CustomerLocationsPage(new CustomerLocationsPageViewModel(_commonServices, this, partner)));

        public void GoToCustomersPage() => GoToPage(new CustomersPage(new CustomersPageViewModel(_commonServices, this)));

        public void GoToMainPage() => GoToPage(new MainPage(new MainPageViewModel(_commonServices, this)));

        public void GoToStartPage() => GoToPage(new StartPage(new StartPageViewModel(_commonServices, this)));

        static void GoToPage(Page page)
        {
            Application.Current.MainPage = page;
        }
    }
}
