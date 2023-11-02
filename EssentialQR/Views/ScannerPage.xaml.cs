using EssentialQR.ViewModels;

namespace EssentialQR.Views;

public partial class ScannerPage : ContentPage
{
    private int _camViewChildIndex;
    private readonly ScannerViewModel _vm;

    public ScannerPage()
	{
		InitializeComponent();
        BindingContext = _vm = new ScannerViewModel();

        _camViewChildIndex = CamGrid.Children.IndexOf(cameraBarcodeReaderView);
    }

    private void BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
		Dispatcher.Dispatch(async () =>
		{

            string QRValue = e.Results[0].Value;

            // Register the result
            _vm.RegisterResult(QRValue);
        });
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        

    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        // NOTE: Workaround for  this issue: https://github.com/Redth/ZXing.Net.Maui/issues/7
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