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

        GlavniGrid.Children.Clear();

    
        var matchesViewModel = App.ServiceProvider.GetRequiredService<MatchesViewModel>();
        var matchesViewKontrola = new MatchesViewxaml
        {
            DataContext = matchesViewModel
        };

        GlavniGrid.Children.Add(matchesViewKontrola);
    }

    private void OpenStuffButton_Click(object sender, RoutedEventArgs e)
    {
     
        GlavniGrid.Children.Clear();

     
        var stuffViewModel = App.ServiceProvider.GetRequiredService<Modules.Stuff.Ui.Viewmodels.StuffViewModel>();
        var stuffViewKontrola = new Modules.Stuff.Ui.View.StuffView
        {
            DataContext = stuffViewModel
        };

        GlavniGrid.Children.Add(stuffViewKontrola);
    }
}