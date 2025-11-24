using System.ComponentModel;

namespace OathAuto.Models
{
  public class InventoryItem : INotifyPropertyChanged
  {
    private int _id;
    private string _name = string.Empty;
    private bool _isSelected;

    public int Id
    {
      get => _id;
      set
      {
        _id = value;
        OnPropertyChanged("Id");
      }
    }

    public string Name
    {
      get => _name;
      set
      {
        _name = value;
        OnPropertyChanged("Name");
      }
    }

    public bool IsSelected
    {
      get => _isSelected;
      set
      {
        _isSelected = value;
        OnPropertyChanged("IsSelected");
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
