using Microsoft.Extensions.DependencyInjection;
using Modules.Matches.Ui.ViewModels;
using Modules.Matches.Ui.View;
using Modules.Teams.UI.Viewmodels;
using Modules.Teams.UI.Views;
using System.Windows;

namespace ProjekatASPIspit;

public partial class MainWindow : Window
{
    private readonly TeamsViewModel _teamsViewModel;

    public MainWindow(TeamsViewModel teamsViewModel)
    {
        InitializeComponent();

        _teamsViewModel = teamsViewModel;
        this.DataContext = _teamsViewModel;

        // Inicijalni prikaz Teams modula u gridu
        var teamsViewKontrola = new TeamsView();
        teamsViewKontrola.DataContext = _teamsViewModel;
        GlavniGrid.Children.Add(teamsViewKontrola);
    }

    private void OpenMatchesButton_Click(object sender, RoutedEventArgs e)
    {
        // Očisti prethodni sadržaj iz grida
        GlavniGrid.Children.Clear();

        // Povuci Matches ViewModel preko DI kontejnera i postavi DataContext preko objektne inicijalizacije
        var matchesViewModel = App.ServiceProvider.GetRequiredService<MatchesViewModel>();
        var matchesViewKontrola = new MatchesViewxaml
        {
            DataContext = matchesViewModel
        };

        // Dodaj kontrolu u glavni grid
        GlavniGrid.Children.Add(matchesViewKontrola);
    }
}