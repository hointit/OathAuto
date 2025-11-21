using System.ComponentModel;

namespace OathAuto.Models
{
  public class Item : INotifyPropertyChanged
  {
    private int _id;
    private string _name = string.Empty;
    private bool _isSelected;
    private int _delay;
    private int _guid1 = 0;
    private int _guid2 = 0;

    public int GUID1
    {
      get => _guid1;
      set
      {
        _guid1 = value;
        OnPropertyChanged("GUID1");
      }
    }

    public int GUID2
    {
      get => _guid2;
      set
      {
        _guid2 = value;
        OnPropertyChanged("GUID2");
      }
    }

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

    public int Delay
    {
      get => _delay;
      set
      {
        _delay = value;
        OnPropertyChanged("Delay");
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
