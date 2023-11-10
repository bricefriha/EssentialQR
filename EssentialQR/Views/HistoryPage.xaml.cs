using EssentialQR.ViewModels;

namespace EssentialQR.Views;

public partial class HistoryPage : ContentPage
{
	public HistoryPage()
	{
		InitializeComponent();
		BindingContext = new HistoryViewModel();
	}
}