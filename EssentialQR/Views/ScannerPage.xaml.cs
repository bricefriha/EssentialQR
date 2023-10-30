namespace EssentialQR.Views;

public partial class ScannerPage : ContentPage
{
    private int _camViewChildIndex;

    public ScannerPage()
	{
		InitializeComponent();

        _camViewChildIndex = CamGrid.Children.IndexOf(cameraBarcodeReaderView);
    }

    private void BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
		Dispatcher.Dispatch(async () =>
		{

            string QRValue = e.Results[0].Value;

            await DisplayAlert("Scan result", QRValue, "Ok");
        });
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        

    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        // Workaround this issue
        ResetCamera();
    }

    private void ResetCamera()
    {
        
        var newCam = new ZXing.Net.Maui.Controls.CameraBarcodeReaderView()
        {
            Options = cameraBarcodeReaderView.Options,
            CameraLocation = cameraBarcodeReaderView.CameraLocation,
        };

        CamGrid.Children.Remove(cameraBarcodeReaderView);
        CamGrid.Children.Insert(_camViewChildIndex, cameraBarcodeReaderView);

        cameraBarcodeReaderView = newCam;

    }
}