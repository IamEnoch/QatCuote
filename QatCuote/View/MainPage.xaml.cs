using QatCuote.ViewModels;

namespace QatCuote;

public partial class MainPage : ContentPage
{
	public MainPage(FactViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}


}