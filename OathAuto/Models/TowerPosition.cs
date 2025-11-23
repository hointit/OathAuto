using System.ComponentModel;

namespace OathAuto.Models
{
  public class TowerPosition : INotifyPropertyChanged
  {
    private float _x;
    private float _y;
    private bool _isChecked = true;
    private string _name;

    public float X
    {
      get => _x;
      set
      {
        if (_x != value)
        {
          _x = value;
          OnPropertyChanged(nameof(X));
        }
      }
    }

    public float Y
    {
      get => _y;
      set
      {
        if (_y != value)
        {
          _y = value;
          OnPropertyChanged(nameof(Y));
        }
      }
    }

    public bool IsChecked
    {
      get => _isChecked;
      set
      {
        if (_isChecked != value)
        {
          _isChecked = value;
          OnPropertyChanged(nameof(IsChecked));
        }
      }
    }

    public string Name
    {
      get => _name;
      set
      {
        if (_name != value)
        {
          _name = value;
          OnPropertyChanged(nameof(Name));
        }
      }
    }

    public string DisplayName => $"{Name} ({X:F0}, {Y:F0})";

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
