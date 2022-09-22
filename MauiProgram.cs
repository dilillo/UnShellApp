using CommunityToolkit.Maui;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace UnShellApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

#pragma warning disable CA1416 // Validate platform compatibility
        builder
            .UseMauiApp<App>()
			.UseMauiCommunityToolkit()
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .ConfigureMauiHandlers(h => h.AddHandler(typeof(CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler)));
#pragma warning restore CA1416 // Validate platform compatibility

        builder.Services.AddSingleton<IPageNavigator, PageNavigator>();
        builder.Services.AddSingleton<IUserAuthenticationService, UserAuthenticationService>();
        builder.Services.AddSingleton<IConnectedProductsApiClient, ConnectedProductsApiClient>();
        builder.Services.AddSingleton<ICommonServices, CommonServices>();

        return builder.Build();
	}
}
