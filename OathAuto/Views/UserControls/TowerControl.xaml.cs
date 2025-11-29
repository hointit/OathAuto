using System;
using System.Collections.Generic;
using System.Linq;
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
using OathAuto.ViewModels;

namespace OathAuto.Views.UserControls
{
    /// <summary>
    /// Interaction logic for TowerControl.xaml
    /// </summary>
    public partial class TowerControl : UserControl
    {
        public TowerControl()
        {
            InitializeComponent();
        }

        private void TowerPosition_Loaded(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null || radioButton.Tag == null)
                return;

            var viewModel = this.DataContext as PlayerViewModel;
            if (viewModel == null || viewModel.Settings == null)
                return;

            int positionId;
            if (int.TryParse(radioButton.Tag.ToString(), out positionId))
            {
                radioButton.IsChecked = (positionId == viewModel.Settings.TowerPositionId);
            }
        }

        private void TowerPosition_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null || radioButton.Tag == null)
                return;

            var viewModel = this.DataContext as PlayerViewModel;
            if (viewModel == null || viewModel.Settings == null)
                return;

            int positionId;
            if (int.TryParse(radioButton.Tag.ToString(), out positionId))
            {
                viewModel.Settings.TowerPositionId = positionId;
            }
        }
    }
}
