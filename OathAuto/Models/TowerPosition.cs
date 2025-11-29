using System.ComponentModel;

namespace OathAuto.Models
{
  public class TowerPosition : INotifyPropertyChanged
  {
    private int _id;
    private Position _position;
    private Position _middlePosition;
    private Position _subPostion;
    private bool _isSelected = true;
    private string _name;

    public int Id
    {
      get => _id;
      set
      {
        if (_id != value)
        {
          _id = value;
          OnPropertyChanged(nameof(Id));
        }
      }
    }

    public Position Position
    {
      get => _position;
      set
      {
        if (_position != value)
        {
          _position = value;
          OnPropertyChanged(nameof(Position));
        }
      }
    }
    public Position SubPostion
    {
      get => _subPostion;
      set
      {
        if (_subPostion != value)
        {
          _subPostion = value;
          OnPropertyChanged(nameof(SubPostion));
        }
      }
    }

    public Position MiddlePosition
    {
      get => _middlePosition;
      set
      {
        if (_middlePosition != value)
        {
          _middlePosition = value;
          OnPropertyChanged(nameof(MiddlePosition));
        }
      }
    }

    public bool IsSelected
    {
      get => _isSelected;
      set
      {
        if (_isSelected != value)
        {
          _isSelected = value;
          OnPropertyChanged(nameof(IsSelected));
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

    public string DisplayName => $"{Name} ({Position.X:F0}, {Position.Y:F0})";

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
