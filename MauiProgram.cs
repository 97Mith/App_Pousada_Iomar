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
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<ICompanyRepository, CompanyRepository>();
        builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

        return builder.Build();
    }

}
