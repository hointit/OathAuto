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
    private bool _isAutoMoveEnabled;
    private int _towerPositionId;
    private string _selectedSkillIdsJson;
    private string _checkedItemIdsJson;
    private int _selectedPetId = 0;

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

    public int TowerPositionId
    {
      get => _towerPositionId;
      set
      {
        if (_towerPositionId != value)
        {
          _towerPositionId = value;
          OnPropertyChanged(nameof(TowerPositionId));
        }
      }
    }

    // Skill Settings
    public string SelectedSkillIdsJson
    {
      get => _selectedSkillIdsJson;
      set => _selectedSkillIdsJson = value;
    }

    // Inventory Item Settings
    public string CheckedItemIdsJson
    {
      get => _checkedItemIdsJson;
      set => _checkedItemIdsJson = value;
    }

    // Pet Settings
    public int SelectedPetId
    {
      get => _selectedPetId;
      set
      {
        if (_selectedPetId != value)
        {
          _selectedPetId = value;
          OnPropertyChanged(nameof(SelectedPetId));
        }
      }
    }

    protected void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
