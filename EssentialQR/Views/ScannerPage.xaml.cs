namespace EssentialQR.Views;

public partial class ScannerPage : ContentPage
{
	public ScannerPage()
	{
		InitializeComponent();
	}

    private void BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
		Dispatcher.Dispatch(async () =>
		{

            string QRValue = e.Results[0].Value;

            await DisplayAlert("Scan result", QRValue, "Ok");
        });
    }
}