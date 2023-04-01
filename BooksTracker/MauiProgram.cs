using BooksTracker.Models;
using BooksTracker.Services;
using BooksTracker.ViewModels;
using BooksTracker.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Supabase;

namespace BooksTracker;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        // Configure Supabase
        var url = AppConfig.SUPABASE_URL;
        var key = AppConfig.SUPABASE_KEY;
        var options = new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true,
        };

        builder.Services.AddSingleton(provider => new Supabase.Client(url, key, options));

        // Add ViewModels
        builder.Services.AddSingleton<BooksListingViewModel>();
        builder.Services.AddTransient<AddBookViewModel>();
        builder.Services.AddTransient<UpdateBookViewModel>();
        
        // Add Views
        builder.Services.AddSingleton<BooksListingPage>();
        builder.Services.AddTransient<AddBookPage>();
        builder.Services.AddTransient<UpdateBookPage>();

        // Add Data Service
        builder.Services.AddSingleton<IDataService, DataService>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
