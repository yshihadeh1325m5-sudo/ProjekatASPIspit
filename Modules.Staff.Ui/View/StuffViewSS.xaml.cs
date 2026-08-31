
using Modules.Stuff.Ui.Viewmodels;
using System.Windows.Controls;

namespace Modules.Stuff.Ui.View
{
    public partial class StuffView : UserControl
    {
        public StuffView()
        {
            InitializeComponent();
        }

        public StuffView(StuffViewModel viewModel) : this()
        {
            DataContext = viewModel;
        }
    }
}