using ZXing.Net.Maui;

namespace UnShellApp;

public partial class AddProductSerialNumberScanPage : ContentPage
{
	public AddProductSerialNumberScanPage(AddProductSerialNumberScanPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;

        viewModel.CancelPopupService = new AddProductCancelPopupService(this);

#pragma warning disable CA1416 // Validate platform compatibility
        scannerView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = true
        };
#pragma warning restore CA1416 // Validate platform compatibility

    }
    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(() => {
#pragma warning disable CA1416 // Validate platform compatibility
            var scannedText = e.Results.First();

            var viewModel = (AddProductSerialNumberScanPageViewModel)BindingContext;

            viewModel.SerialNumber = scannedText.Value;

            viewModel.GoToSerialNumberSearchPageCommand.Execute(null);
#pragma warning restore CA1416 // Validate platform compatibility
        });
    }
}