using Modules.Matches.Ui.ViewModels;
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

namespace Modules.Matches.Ui.View
{

    public partial class PlayersViewxaml : UserControl
    {
        public PlayersViewxaml()
        {
            InitializeComponent();
        }

        public PlayersViewxaml(PlayersViewModel viewModel) : this()
        {
            DataContext = viewModel;
        }


    }
}
