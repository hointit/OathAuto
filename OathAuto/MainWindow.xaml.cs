using OathAuto.Tools.Services;
using OathAuto.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace OathAuto
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private MainWindowViewModel _viewModel;

    public MainWindow()
    {
      InitializeComponent();
      _viewModel = new MainWindowViewModel();
      DataContext = _viewModel;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      // Cleanup resources
      _viewModel?.Cleanup();
      base.OnClosing(e);
    }

    private void PositionFinder_Click(object sender, RoutedEventArgs e)
    {
      // Launch the Position Finder overlay tool
      PositionFinderService.Show();
    }
  }
}
