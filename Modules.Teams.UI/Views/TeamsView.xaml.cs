using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Modules.Teams.UI.Viewmodels;



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
            // Ručno i sigurno pokrećemo osvežavanje tabele na samom startu
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

}