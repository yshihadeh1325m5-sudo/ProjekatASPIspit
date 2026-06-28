using System.Windows;
using Modules.Teams.UI.Views; // 👈 Direktan using za tvoj TeamsView
using Modules.Teams.UI.Viewmodels;

namespace ProjekatASPIspit;

public partial class MainWindow : Window
{
    public MainWindow(TeamsViewModel teamsViewModel)
    {
        InitializeComponent();

        // 1. Vezujemo ViewModel za glavni prozor
        this.DataContext = teamsViewModel;

        // 2. Pravimo TeamsView direktno kroz C# (tako zaobilazimo bagoviti XAML dizajner)
        var teamsViewKontrola = new TeamsView();

        // 3. Prosleđujemo joj isti ovaj ViewModel da bi tabela videla podatke
        teamsViewKontrola.DataContext = teamsViewModel;

        // 4. Ubacujemo je unutar ekrana u naš Grid
        GlavniGrid.Children.Add(teamsViewKontrola);
    }
}