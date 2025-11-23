using System.ComponentModel;
using System.Windows.Input;
using OathAuto.ViewModels;

namespace OathAuto.Models
{
  public class Skill : INotifyPropertyChanged
  {
    private string _menpai;
    private int _skillbook;
    private int _bookslot;
    private int _skillid;
    private string _skillname;
    private int _ragerequired;
    private int _pkslot;
    private int _trainslot;
    private int _buffperiod;
    private int _isattack;
    private int _isbuff;
    private int _special;
    private string _comment;
    private bool _isChecked;
    private ICommand _checkedChangedCommand;

    public string Menpai
    {
      get => _menpai;
      set
      {
        if (_menpai != value)
        {
          _menpai = value;
          OnPropertyChanged(nameof(Menpai));
        }
      }
    }

    public int SkillBook
    {
      get => _skillbook;
      set
      {
        if (_skillbook != value)
        {
          _skillbook = value;
          OnPropertyChanged(nameof(SkillBook));
        }
      }
    }

    public int BookSlot
    {
      get => _bookslot;
      set
      {
        if (_bookslot != value)
        {
          _bookslot = value;
          OnPropertyChanged(nameof(BookSlot));
        }
      }
    }

    public int SkillId
    {
      get => _skillid;
      set
      {
        if (_skillid != value)
        {
          _skillid = value;
          OnPropertyChanged(nameof(SkillId));
        }
      }
    }

    public string SkillName
    {
      get => _skillname;
      set
      {
        if (_skillname != value)
        {
          _skillname = value;
          OnPropertyChanged(nameof(SkillName));
        }
      }
    }

    public int RageRequired
    {
      get => _ragerequired;
      set
      {
        if (_ragerequired != value)
        {
          _ragerequired = value;
          OnPropertyChanged(nameof(RageRequired));
        }
      }
    }

    public int PkSlot
    {
      get => _pkslot;
      set
      {
        if (_pkslot != value)
        {
          _pkslot = value;
          OnPropertyChanged(nameof(PkSlot));
        }
      }
    }

    public int TrainSlot
    {
      get => _trainslot;
      set
      {
        if (_trainslot != value)
        {
          _trainslot = value;
          OnPropertyChanged(nameof(TrainSlot));
        }
      }
    }

    public int BuffPeriod
    {
      get => _buffperiod;
      set
      {
        if (_buffperiod != value)
        {
          _buffperiod = value;
          OnPropertyChanged(nameof(BuffPeriod));
        }
      }
    }

    public int IsAttack
    {
      get => _isattack;
      set
      {
        if (_isattack != value)
        {
          _isattack = value;
          OnPropertyChanged(nameof(IsAttack));
        }
      }
    }

    public int IsBuff
    {
      get => _isbuff;
      set
      {
        if (_isbuff != value)
        {
          _isbuff = value;
          OnPropertyChanged(nameof(IsBuff));
        }
      }
    }

    public int Special
    {
      get => _special;
      set
      {
        if (_special != value)
        {
          _special = value;
          OnPropertyChanged(nameof(Special));
        }
      }
    }

    public string Comment
    {
      get => _comment;
      set
      {
        if (_comment != value)
        {
          _comment = value;
          OnPropertyChanged(nameof(Comment));
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

          // Execute command when checkbox state changes
          if (_checkedChangedCommand != null && _checkedChangedCommand.CanExecute(this))
          {
            _checkedChangedCommand.Execute(this);
          }
        }
      }
    }

    public ICommand CheckedChangedCommand
    {
      get => _checkedChangedCommand;
      set
      {
        if (_checkedChangedCommand != value)
        {
          _checkedChangedCommand = value;
          OnPropertyChanged(nameof(CheckedChangedCommand));
        }
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
