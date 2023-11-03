using EssentialQR.ViewModels;
using System.Collections.Generic;
using ZXing.Net.Maui;

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
        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            AutoRotate = false,
            TryHarder = true,
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
        };
        cameraBarcodeReaderView.IsDetecting = true ;
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