using QatCuote.Services;
using QatCuote.ViewModels;

namespace QatCuote;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<CatService>();

		builder.Services.AddSingleton<FactViewModel>();

		return builder.Build();
	}
}
