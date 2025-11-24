using System.ComponentModel;

namespace OathAuto.Models
{
  public class PlayerSettings : INotifyPropertyChanged
  {
    private int _playerId;
    private PlayerMode _mode = PlayerMode.None;
    private bool _isAutoUpLevel;
    private bool _isAutoUseX2Exp;
    private bool _isAutoUseResetLevelItem;
    private bool _isAutoUseAddPointItem;
    private int _maxLevel = 130;
    private int _fixedX;
    private int _fixedY;
    private int _fixedMapId;
    private string _fixedMapName = "";
    private bool _useItemWithoutTraining;
    private bool _isAutoMoveEnabled;
    private string _towerPositionsJson;
    private string _selectedSkillIdsJson;
    private string _checkedItemIndexesJson;

    public event PropertyChangedEventHandler PropertyChanged;

    public int PlayerId
    {
      get => _playerId;
      set
      {
        if (_playerId != value)
        {
          _playerId = value;
          OnPropertyChanged(nameof(PlayerId));
        }
      }
    }

    // Player Mode (0 = None, 1 = Training, 2 = FightTower)
    public PlayerMode Mode
    {
      get => _mode;
      set
      {
        if (_mode != value)
        {
          _mode = value;
          OnPropertyChanged(nameof(Mode));
        }
      }
    }

    public bool IsAutoUpLevel
    {
      get => _isAutoUpLevel;
      set
      {
        if (_isAutoUpLevel != value)
        {
          _isAutoUpLevel = value;
          OnPropertyChanged(nameof(IsAutoUpLevel));
        }
      }
    }

    public bool IsAutoUseX2Exp
    {
      get => _isAutoUseX2Exp;
      set
      {
        if (_isAutoUseX2Exp != value)
        {
          _isAutoUseX2Exp = value;
          OnPropertyChanged(nameof(IsAutoUseX2Exp));
        }
      }
    }

    public bool IsAutoUseResetLevelItem
    {
      get => _isAutoUseResetLevelItem;
      set
      {
        if (_isAutoUseResetLevelItem != value)
        {
          _isAutoUseResetLevelItem = value;
          OnPropertyChanged(nameof(IsAutoUseResetLevelItem));
        }
      }
    }

    public bool IsAutoUseAddPointItem
    {
      get => _isAutoUseAddPointItem;
      set
      {
        if (_isAutoUseAddPointItem != value)
        {
          _isAutoUseAddPointItem = value;
          OnPropertyChanged(nameof(IsAutoUseAddPointItem));
        }
      }
    }

    public int MaxLevel
    {
      get => _maxLevel;
      set
      {
        if (_maxLevel != value)
        {
          _maxLevel = value;
          OnPropertyChanged(nameof(MaxLevel));
        }
      }
    }

    public int FixedX
    {
      get => _fixedX;
      set
      {
        if (_fixedX != value)
        {
          _fixedX = value;
          OnPropertyChanged(nameof(FixedX));
        }
      }
    }

    public int FixedY
    {
      get => _fixedY;
      set
      {
        if (_fixedY != value)
        {
          _fixedY = value;
          OnPropertyChanged(nameof(FixedY));
        }
      }
    }

    public int FixedMapId
    {
      get => _fixedMapId;
      set
      {
        if (_fixedMapId != value)
        {
          _fixedMapId = value;
          OnPropertyChanged(nameof(FixedMapId));
        }
      }
    }

    public string FixedMapName
    {
      get => _fixedMapName;
      set
      {
        if (_fixedMapName != value)
        {
          _fixedMapName = value ?? "";
          OnPropertyChanged(nameof(FixedMapName));
        }
      }
    }

    public bool UseItemWithoutTraining
    {
      get => _useItemWithoutTraining;
      set
      {
        if (_useItemWithoutTraining != value)
        {
          _useItemWithoutTraining = value;
          OnPropertyChanged(nameof(UseItemWithoutTraining));
        }
      }
    }

    // Tower Settings
    public bool IsAutoMoveEnabled
    {
      get => _isAutoMoveEnabled;
      set
      {
        if (_isAutoMoveEnabled != value)
        {
          _isAutoMoveEnabled = value;
          OnPropertyChanged(nameof(IsAutoMoveEnabled));
        }
      }
    }

    public string TowerPositionsJson
    {
      get => _towerPositionsJson;
      set
      {
        if (_towerPositionsJson != value)
        {
          _towerPositionsJson = value;
          OnPropertyChanged(nameof(TowerPositionsJson));
        }
      }
    }

    // Skill Settings
    public string SelectedSkillIdsJson
    {
      get => _selectedSkillIdsJson;
      set
      {
        if (_selectedSkillIdsJson != value)
        {
          _selectedSkillIdsJson = value;
          OnPropertyChanged(nameof(SelectedSkillIdsJson));
        }
      }
    }

    // Inventory Item Settings
    public string CheckedItemIndexesJson
    {
      get => _checkedItemIndexesJson;
      set
      {
        if (_checkedItemIndexesJson != value)
        {
          _checkedItemIndexesJson = value;
          OnPropertyChanged(nameof(CheckedItemIndexesJson));
        }
      }
    }

    protected void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
