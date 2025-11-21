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
  }
}
