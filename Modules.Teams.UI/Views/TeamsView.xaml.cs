using Microsoft.Extensions.DependencyInjection;
using Modules.Coaches.Ui.View;
using Modules.Coaches.Ui.Viewmodels;
using Modules.Matches.Ui.View;
using Modules.Matches.Ui.ViewModels;
using Modules.Stuff.Ui.View;
using Modules.Stuff.Ui.Viewmodels;
using Modules.Teams.UI.Viewmodels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Modules.Teams.UI.Views;

public partial class TeamsView : UserControl
{
    public TeamsView()
    {
        InitializeComponent();
        this.Loaded += TeamsView_Loaded;
    }

    private async void TeamsView_Loaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is TeamsViewModel vm)
        {
            await vm.UcitajTimoveAsync();
        }
    }

    private async void BtnDodaj_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is TeamsViewModel vm)
        {
            var name = TxtName.Text;
            var stadium = TxtStadium.Text;

            if (!string.IsNullOrWhiteSpace(name))
            {
                await vm.DodajTimAsync(name, stadium);

                TxtName.Clear();
                TxtStadium.Clear();
            }
        }
    }

    private void BtnOtvoriMatches_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = global::System.Windows.Application.Current.MainWindow;
        if (mainWindow != null)
        {
            var glavniGrid = mainWindow.FindName("GlavniGrid") as Grid;
            if (glavniGrid != null)
            {
                glavniGrid.Children.Clear();

                var app = global::System.Windows.Application.Current;
                IServiceProvider provider = ((dynamic)app).GetServiceProvider();
                var matchesViewModel = provider.GetRequiredService<MatchesViewModel>();

                var matchesView = new MatchesViewxaml
                {
                    DataContext = matchesViewModel
                };
                glavniGrid.Children.Add(matchesView);
            }
        }
    }

    private void BtnOtvoriStuff_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = global::System.Windows.Application.Current.MainWindow;
        if (mainWindow != null)
        {
            var glavniGrid = mainWindow.FindName("GlavniGrid") as Grid;
            if (glavniGrid != null)
            {
                glavniGrid.Children.Clear();

                var app = global::System.Windows.Application.Current;
                IServiceProvider provider = ((dynamic)app).GetServiceProvider();
                var stuffViewModel = provider.GetRequiredService<StuffViewModel>();

                var stuffView = new StuffView
                {
                    DataContext = stuffViewModel
                };
                glavniGrid.Children.Add(stuffView);
            }
        }
    }

    private void BtnOtvoriCoaches_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = global::System.Windows.Application.Current.MainWindow;
        if (mainWindow != null)
        {
            var glavniGrid = mainWindow.FindName("GlavniGrid") as Grid;
            if (glavniGrid != null)
            {
                glavniGrid.Children.Clear();

                var app = global::System.Windows.Application.Current;
                IServiceProvider provider = ((dynamic)app).GetServiceProvider();
                var coachesViewModel = provider.GetRequiredService<CoachesViewModel>();

                var coachesView = new CoachesView(coachesViewModel);
                glavniGrid.Children.Add(coachesView);
            }
        }
    }
}