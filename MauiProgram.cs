using Microsoft.Extensions.Logging;
using PousadaIomar.Repositories;
using PousadaIomar.Interfaces;
using SQLite;

namespace PousadaIomar;

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
            .CreateMauiAppBuilder();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    public static MauiAppBuilder CreateMauiAppBuilder(this MauiAppBuilder maui)
    {
        maui.Services.AddSingleton<SQLiteAsyncConnection>(
            o =>
            {
                return new SQLiteAsyncConnection($"FileName={AppSettings.DatabasePath};Connection=Shared");
            }
            );
        maui.Services.AddTransient<ICompanyRepository, CompanyRepository>();
        maui.Services.AddTransient<IPersonRepository, PersonRepository>();

        return maui;
    }
}
