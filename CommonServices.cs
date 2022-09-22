namespace UnShellApp
{
    public interface ICommonServices
    {
        IUserAuthenticationService UserAuthentication { get; }

        IConnectedProductsApiClient ConnectedProductsApiClient { get; }
    }

    public class CommonServices : ICommonServices
    {
        public CommonServices(
            IUserAuthenticationService userAuthenticationService, 
            IConnectedProductsApiClient connectedProductsApiClient)
        {
            UserAuthentication = userAuthenticationService;
            ConnectedProductsApiClient = connectedProductsApiClient;
        }

        public IUserAuthenticationService UserAuthentication { get; }

        public IConnectedProductsApiClient ConnectedProductsApiClient { get; }
    }
}
