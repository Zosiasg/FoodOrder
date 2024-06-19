using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using FoodOrder.Services;
using FoodOrder.ViewModels;
using FoodOrder.Pages;

namespace FoodOrder;

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
			})
			.UseMauiCommunityToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif
		AddDishServices(builder.Services);

        return builder.Build();
	}

	private static IServiceCollection AddDishServices(IServiceCollection services)
	{
		services.AddSingleton<DishService>();

		services.AddSingleton<HomePage>()
				.AddSingleton<HomeViewModel>();

		services.AddTransientWithShellRoute<AllDishsPage, AllDishViewModel>(nameof(AllDishsPage));

        services.AddTransientWithShellRoute<DetailPage, DetailsViewModel>(nameof(DetailPage));

		services.AddSingleton<CartViewModel>();
		services.AddTransient<CartPage>();
        return services;
	}
}
