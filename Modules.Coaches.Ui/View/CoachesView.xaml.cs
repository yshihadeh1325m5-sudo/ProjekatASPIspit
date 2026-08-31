using System.Windows.Controls;
using Modules.Coaches.Ui.Viewmodels;

namespace Modules.Coaches.Ui.View
{
    public partial class CoachesView : UserControl
    {
        public CoachesView(CoachesViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}