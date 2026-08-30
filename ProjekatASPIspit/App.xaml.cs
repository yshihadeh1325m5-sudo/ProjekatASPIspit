using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Matches.Infrastructure;
using Modules.Matches.Ui.ViewModels;
using Modules.Teams.Infrastructure;
using Modules.Teams.UI.Viewmodels;
using System;
using System.IO;
using System.Windows;

namespace ProjekatASPIspit;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    // Nestatička metoda koja omogućava modulima da bezbedno pristupe statičkom kontejneru preko dynamic-a
    public IServiceProvider GetServiceProvider() => ServiceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var services = new ServiceCollection();

        services.AddTeamsModule(configuration);
        services.AddMatchesModule(configuration);

        services.AddTransient<TeamsViewModel>();
        services.AddTransient<MatchesViewModel>();
        services.AddTransient<MainWindow>();

        // Izgradnja kontejnera
        ServiceProvider = services.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}