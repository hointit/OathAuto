# MVVM Usage Example for OathAuto

## Architecture Overview

This document explains how to use the MVVM structure for displaying and managing multiple game accounts with real-time updates.

## Components

### 1. **Player Model** (`Models/Player.cs`)
- Pure data model with `INotifyPropertyChanged`
- Contains player properties: Name, HP, MP, Position, etc.
- No business logic

### 2. **PlayerViewModel** (`ViewModels/PlayerViewModel.cs`)
- Wraps a single `Player` model
- Contains player-specific action commands:
  - `StartTrainingCommand`
  - `StopTrainingCommand`
  - `UseItemCommand`
- Holds reference to `SmartClassService` and account index for executing commands
- Re-raises property changes from the wrapped Player model

### 3. **MainWindowViewModel** (`ViewModels/MainWindowViewModel.cs`)
- Manages `ObservableCollection<PlayerViewModel>` for the player list
- Handles `SelectedPlayer` for master-detail pattern
- Subscribes to `SmartClassService.PlayerDataUpdated` event (300ms updates)
- Automatically updates existing PlayerViewModels with new data
- Marshals updates to UI thread using `Dispatcher`

### 4. **SmartClassService** (`Services/SmartClassService.cs`)
- Wraps CoreLibrary's `SmartClass`
- Provides 300ms timer for real-time data updates
- Fires `PlayerDataUpdated` event with `List<Player>`
- Maps `AutoAccount` to `Player` model

## How to Use in MainWindow

### Step 1: MainWindow.xaml.cs

```csharp
using System.Windows;
using OathAuto.ViewModels;

namespace OathAuto
{
  public partial class MainWindow : Window
  {
    private MainWindowViewModel _viewModel;

    public MainWindow()
    {
      InitializeComponent();

      // Create and set DataContext
      _viewModel = new MainWindowViewModel();
      DataContext = _viewModel;
    }

    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
      // Cleanup when window closes
      _viewModel?.Cleanup();
      base.OnClosing(e);
    }
  }
}
```

### Step 2: MainWindow.xaml (Basic Example)

```xml
<Window x:Class="OathAuto.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="OathAuto - Game Automation" Height="600" Width="900">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="300"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>

        <!-- Left Side: Player List -->
        <GroupBox Grid.Column="0" Header="Players" Margin="5">
            <ListBox ItemsSource="{Binding Players}"
                     SelectedItem="{Binding SelectedPlayer}"
                     DisplayMemberPath="Name">
                <!-- Or use ItemTemplate for custom display -->
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <TextBlock Text="{Binding Name}" FontWeight="Bold" Width="100"/>
                            <TextBlock Text="Lv." Margin="5,0,2,0"/>
                            <TextBlock Text="{Binding Level}"/>
                            <TextBlock Text=" | HP: " Margin="5,0,2,0"/>
                            <TextBlock Text="{Binding HPPercent, StringFormat={}{0:F0}%}"/>
                        </StackPanel>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
        </GroupBox>

        <!-- Right Side: Selected Player Details and Actions -->
        <GroupBox Grid.Column="1" Header="Player Details" Margin="5">
            <StackPanel DataContext="{Binding SelectedPlayer}">
                <!-- Player Information -->
                <GroupBox Header="Information" Margin="5">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto"/>
                            <ColumnDefinition Width="*"/>
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="Auto"/>
                        </Grid.RowDefinitions>

                        <TextBlock Grid.Row="0" Grid.Column="0" Text="Name:" Margin="5"/>
                        <TextBlock Grid.Row="0" Grid.Column="1" Text="{Binding Name}" Margin="5" FontWeight="Bold"/>

                        <TextBlock Grid.Row="1" Grid.Column="0" Text="Level:" Margin="5"/>
                        <TextBlock Grid.Row="1" Grid.Column="1" Text="{Binding Level}" Margin="5"/>

                        <TextBlock Grid.Row="2" Grid.Column="0" Text="HP:" Margin="5"/>
                        <StackPanel Grid.Row="2" Grid.Column="1" Orientation="Horizontal" Margin="5">
                            <TextBlock Text="{Binding HP}"/>
                            <TextBlock Text=" / "/>
                            <TextBlock Text="{Binding MaxHP}"/>
                            <TextBlock Text=" (" Margin="5,0,0,0"/>
                            <TextBlock Text="{Binding HPPercent, StringFormat={}{0:F1}%}"/>
                            <TextBlock Text=")"/>
                        </StackPanel>

                        <TextBlock Grid.Row="3" Grid.Column="0" Text="MP:" Margin="5"/>
                        <StackPanel Grid.Row="3" Grid.Column="1" Orientation="Horizontal" Margin="5">
                            <TextBlock Text="{Binding MP}"/>
                            <TextBlock Text=" / "/>
                            <TextBlock Text="{Binding MaxMP}"/>
                            <TextBlock Text=" (" Margin="5,0,0,0"/>
                            <TextBlock Text="{Binding MPPercent, StringFormat={}{0:F1}%}"/>
                            <TextBlock Text=")"/>
                        </StackPanel>

                        <TextBlock Grid.Row="4" Grid.Column="0" Text="Map:" Margin="5"/>
                        <TextBlock Grid.Row="4" Grid.Column="1" Text="{Binding MapName}" Margin="5"/>
                    </Grid>
                </GroupBox>

                <!-- Player Status -->
                <GroupBox Header="Status" Margin="5">
                    <StackPanel>
                        <CheckBox Content="In Combat" IsChecked="{Binding InCombat, Mode=OneWay}" IsEnabled="False" Margin="5"/>
                        <CheckBox Content="Training" IsChecked="{Binding isTraining, Mode=OneWay}" IsEnabled="False" Margin="5"/>
                    </StackPanel>
                </GroupBox>

                <!-- Player Actions -->
                <GroupBox Header="Actions" Margin="5">
                    <StackPanel>
                        <Button Content="Start Training"
                                Command="{Binding StartTrainingCommand}"
                                Margin="5"
                                Padding="10,5"/>
                        <Button Content="Stop Training"
                                Command="{Binding StopTrainingCommand}"
                                Margin="5"
                                Padding="10,5"/>
                        <Button Content="Use Item"
                                Command="{Binding UseItemCommand}"
                                Margin="5"
                                Padding="10,5"/>
                    </StackPanel>
                </GroupBox>
            </StackPanel>
        </GroupBox>
    </Grid>
</Window>
```

## Data Flow

```
┌──────────────────────────────────────────────────────────┐
│ CoreLibrary (SmartClass.AllAutoAccounts)                 │
│ Updates every frame (~300ms)                              │
└────────────────────┬─────────────────────────────────────┘
                     │
                     ▼
┌──────────────────────────────────────────────────────────┐
│ SmartClassService Timer (300ms)                          │
│ - Reads AllAutoAccounts                                   │
│ - Maps AutoAccount → Player                               │
│ - Fires PlayerDataUpdated event                           │
└────────────────────┬─────────────────────────────────────┘
                     │
                     ▼
┌──────────────────────────────────────────────────────────┐
│ MainWindowViewModel.OnPlayerDataUpdated()                │
│ - Receives List<Player> on timer thread                  │
│ - Marshals to UI thread via Dispatcher                   │
│ - Updates existing PlayerViewModels                       │
└────────────────────┬─────────────────────────────────────┘
                     │
                     ▼
┌──────────────────────────────────────────────────────────┐
│ PlayerViewModel.Player properties update                 │
│ - Triggers INotifyPropertyChanged                        │
└────────────────────┬─────────────────────────────────────┘
                     │
                     ▼
┌──────────────────────────────────────────────────────────┐
│ WPF Data Binding updates UI automatically                │
└──────────────────────────────────────────────────────────┘
```

## Key Benefits of This Structure

### ✅ Correct MVVM Pattern
- **Model**: Pure data (Player)
- **ViewModel**: Business logic + Commands (PlayerViewModel, MainWindowViewModel)
- **View**: XAML only, no code-behind logic

### ✅ Reusable PlayerViewModel
- Can be used anywhere you need player display + actions
- Each PlayerViewModel is independent
- Easy to test in isolation

### ✅ Efficient Updates
- ViewModels are **NOT recreated** every 300ms
- Only property values are updated
- WPF data binding handles UI updates automatically

### ✅ Master-Detail Pattern
- List on left shows all players
- Details on right show selected player
- Selected player's actions are available

### ✅ Thread-Safe
- Timer updates come on background thread
- `Dispatcher.BeginInvoke` marshals to UI thread
- No cross-thread exceptions

## Adding New Player Actions

To add a new command to PlayerViewModel:

```csharp
// 1. Add command property
public ICommand TeleportCommand { get; private set; }

// 2. Initialize in InitializeCommands()
TeleportCommand = new RelayCommand(ExecuteTeleport, CanExecuteTeleport);

// 3. Implement CanExecute
private bool CanExecuteTeleport()
{
    return _smartClassService != null && !InCombat;
}

// 4. Implement Execute
private void ExecuteTeleport(object parameter)
{
    if (_smartClassService == null) return;

    // Call SmartClassService method
    _smartClassService.TeleportPlayer(_accountIndex, parameter);
}
```

## Implementing Actions in SmartClassService

Add methods to `SmartClassService.cs` to interact with CoreLibrary:

```csharp
public void StartTraining(int accountIndex)
{
    var accounts = GetAllAccounts();
    if (accountIndex >= 0 && accountIndex < accounts.Count)
    {
        var account = accounts[accountIndex];
        account.Myself.StopTrain = false;
        // Add your training logic here
    }
}

public void StopTraining(int accountIndex)
{
    var accounts = GetAllAccounts();
    if (accountIndex >= 0 && accountIndex < accounts.Count)
    {
        var account = accounts[accountIndex];
        account.Myself.StopTrain = true;
        // Add your stop logic here
    }
}
```

## Summary

This is the **standard and recommended MVVM architecture** for master-detail scenarios with real-time updates. The structure is:

1. **Player** = Data only
2. **PlayerViewModel** = Player wrapper + Commands
3. **MainWindowViewModel** = Collection management + SelectedPlayer
4. **MainWindow.xaml** = Pure UI binding, no logic

This pattern is used in professional WPF applications and follows Microsoft's MVVM guidelines.
