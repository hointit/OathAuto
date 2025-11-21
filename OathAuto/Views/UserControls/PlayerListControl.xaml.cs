using System;
using System.Windows;
using System.Windows.Controls;

namespace OathAuto.Views.UserControls
{
  public partial class PlayerListControl : UserControl
  {
    public PlayerListControl()
    {
      InitializeComponent();
    }

    private void PlayerListView_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      ListView listView = sender as ListView;
      if (listView == null) return;

      GridView gridView = listView.View as GridView;
      if (gridView == null || gridView.Columns.Count == 0) return;

      // Calculate the width of all columns except the last one
      double totalWidth = 0;
      for (int i = 0; i < gridView.Columns.Count - 1; i++)
      {
        totalWidth += gridView.Columns[i].ActualWidth;
      }

      // Set the last column width to fill remaining space
      // Subtract some padding to account for scrollbar and borders
      double remainingWidth = listView.ActualWidth - totalWidth - 25;
      if (remainingWidth > 0)
      {
        gridView.Columns[gridView.Columns.Count - 1].Width = remainingWidth;
      }
    }
  }
}
