using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Windows;
using Modules.Teams.Infrastructure;
using System;
using Modules.Teams.UI.Viewmodels;

namespace ProjekatASPIspit;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // 1. Izgradnja konfiguracije koja čita appsettings.json iz glavnog projekta
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var services = new ServiceCollection();

        // 2. Registracija modula i prosleđivanje konfiguracije za bazu podataka
        services.AddTeamsModule(configuration);

        // Registracija MVVM i UI delova
        services.AddTransient<TeamsViewModel>();
        services.AddTransient<MainWindow>();

        // Izgradnja kontejnera
        ServiceProvider = services.BuildServiceProvider();

        // Ručno tražimo prozor iz DI kontejnera
        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}