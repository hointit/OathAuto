using Newtonsoft.Json;
using OathAuto.AppState;
using OathAuto.Models;
using OathAuto.Services;
using SmartBot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using static SmartBot.AllEnums;
using InventoryItem = OathAuto.Models.InventoryItem;

namespace OathAuto.ViewModels
{
  public partial class PlayerViewModel : INotifyPropertyChanged
  {
    private Player _player;
    private DatabaseService _databaseService;
    private ICommand _skillCheckedChangedCommand;
    private ICommand _getCurrentPositionCommand;
    private ICommand _clearFixedPositionCommand;
    private ICommand _clearSelectedPetCommand;

    #region Commands
    public ICommand SkillCheckedChangedCommand => _skillCheckedChangedCommand;
    public ICommand GetCurrentPositionCommand => _getCurrentPositionCommand;
    public ICommand ClearFixedPositionCommand => _clearFixedPositionCommand;
    public ICommand ClearSelectedPetCommand => _clearSelectedPetCommand;
    #endregion
    private readonly LockStatus _lockRunAction = new LockStatus() { Status = "Lock Action" };

    // Player mode for internal logic
    private PlayerMode _playerMode = PlayerMode.None;

    // Settings - bound directly to UI
    private PlayerSettings _settings;

    public PlayerViewModel(Player player, SmartClassService smartClassService, int accountIndex)
    {
      _player = player ?? new Player();
      _player.PropertyChanged += OnPlayerPropertyChanged;

      string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TLBB.db");
      if (File.Exists(dbPath))
      {
        _databaseService = new DatabaseService(dbPath);
      }

      // Initialize training option commands
      _getCurrentPositionCommand = new RelayCommand(ExecuteGetCurrentPosition);
      _clearFixedPositionCommand = new RelayCommand(ExecuteClearFixedPosition);
      _clearSelectedPetCommand = new RelayCommand(ExecuteClearSelectedPet);

      // Initialize tower positions
      _towerPositions = new ObservableCollection<TowerPosition>
      {
        new TowerPosition { Name = "Vị trí 1", X = 26, Y = 36, IsSelected = true },
        new TowerPosition { Name = "Vị trí 2", X = 36, Y = 34, IsSelected = true },
        new TowerPosition { Name = "Vị trí 3", X = 36, Y = 24, IsSelected = true },
        new TowerPosition { Name = "Vị trí 4", X = 24, Y = 23, IsSelected = true }
      };

      // Subscribe to tower position property changes
      foreach (var pos in _towerPositions)
      {
        pos.PropertyChanged += HandleEventUIChange;
      }
    }

    public void LoadPlayerInventory()
    {
      if (Player == null ||
          Player.AutoAccount == null ||
          Player.AutoAccount.MyInventory == null)
        return;

      try
      {
        var allItems = Player.AutoAccount.MyInventory.AllItems.Take(30).Where(item => item.ItemID > 0).ToList();
        if (allItems == null || allItems.Count == 0) return;

        var settings = Settings;
        var checkedItemIds = new System.Collections.Generic.List<int>();
        // Load checked item IDs from settings if available
        if (settings != null && !string.IsNullOrEmpty(settings.CheckedItemIdsJson))
        {
          try
          {
            checkedItemIds = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<int>>(settings.CheckedItemIdsJson)
                             ?? new System.Collections.Generic.List<int>();
          }
          catch { }
        }

        if (Player.InventoryItems == null || Player.InventoryItems.Count == 0)
        {
          Player.InventoryItems = new ObservableCollection<InventoryItem>();
          foreach (var item in allItems)
          {
            var newItem = new InventoryItem()
            {
              Id = item.ItemID,
              IsSelected = checkedItemIds.Contains(item.ItemID),
              Name = item.ItemName != string.Empty ? item.ItemName : item.ItemID.ToString()
            };


            newItem.PropertyChanged += HandleEventUIChange;
            Player.InventoryItems.Add(newItem);
          }
        }
        else
        {
          foreach (var item in allItems)
          {
            if (Player.InventoryItems.Any(i => i.Id == item.ItemID))
            {
              continue;
            }
            else
            {
              var newItem = new InventoryItem()
              {
                Id = item.ItemID,
                IsSelected = checkedItemIds.Contains(item.ItemID),
                Name = item.ItemName != string.Empty ? item.ItemName : item.ItemID.ToString()
              };
              newItem.PropertyChanged += HandleEventUIChange;
              Player.InventoryItems.Add(newItem);
            }
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine($"Error loading player inventory: {ex.Message}");
      }
    }

    public Player Player
    {
      get => _player;
      set
      {
        if (_player != value)
        {
          if (_player != null)
          {
            _player.PropertyChanged -= OnPlayerPropertyChanged;
          }

          _player = value;
          OnPropertyChanged(nameof(Player));
          if (_player != null)
          {
            _player.PropertyChanged += OnPlayerPropertyChanged;
          }
        }
      }
    }

    public PlayerSettings Settings
    {
      get => _settings;
      set
      {
        if (_settings != value)
        {
          // Unsubscribe from old settings
          if (_settings != null)
          {
            _settings.PropertyChanged -= OnSettingsPropertyChanged;
          }

          _settings = value;
          OnPropertyChanged(nameof(Settings));

          // Subscribe to new settings
          if (_settings != null)
          {
            _settings.PropertyChanged += OnSettingsPropertyChanged;
          }
        }
      }
    }

    // Convenience properties for direct binding (optional)
    public int Id => _player.Id;
    public string Name => _player?.Name ?? string.Empty;
    public string UserName => _player?.UserName ?? string.Empty;
    public Menpais Menpai => _player?.Menpai ?? Menpais.NOMENPAI;
    public string DisplayName => _player?.DisplayName ?? string.Empty;
    public int Level => _player?.Level ?? 0;
    public int HP => _player?.HP ?? 0;
    public int MaxHP => _player?.MaxHP ?? 0;
    public double HPPercent => _player?.HPPercent ?? 0;
    public int MP => _player?.MP ?? 0;
    public int MaxMP => _player?.MaxMP ?? 0;
    public double MPPercent => _player?.MPPercent ?? 0;
    public string MapName => _player?.MapName ?? string.Empty;
    public string MapLocation => _player?.MapLocation ?? string.Empty;
    public bool InCombat => _player?.InCombat ?? false;
    public double ExpPercent => _player?.ExpPercent ?? 0;
    public ObservableCollection<Models.InventoryItem> InventoryItems => _player?.InventoryItems;
    public int DatabaseId => _player.DatabaseId;

    // Direct Mode property for XAML binding
    public PlayerMode Mode
    {
      get => _playerMode;
      set
      {
        if (_playerMode != value)
        {
          var oldMode = _playerMode;
          _playerMode = value;

          // Update settings
          if (_settings != null)
          {
            _settings.Mode = value;
          }

          // Handle mode-specific logic
          switch (value)
          {
            case PlayerMode.None:
              SetTrainingState(false);
              Debug.WriteLine("None Mode - Player Idle");
              break;

            case PlayerMode.Training:
              SetTrainingState(true);
              Debug.WriteLine("Training Mode Enabled");
              break;

            case PlayerMode.FightTower:
              SetTrainingState(false);
              _currentPositionIndex = 0;
              _isMovingForward = true;
              Debug.WriteLine("Tower Mode Enabled - Starting ping-pong patrol");
              break;
          }

          OnPropertyChanged(nameof(Mode));
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
    private void OnPlayerPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      OnPropertyChanged(e.PropertyName);
    }


    public void RunAction(bool isChangeMap = false)
    {
      ThreadPool.QueueUserWorkItem(state =>
      {
        lock (_lockRunAction)
        {
          if (isChangeMap)
          {
            Thread.Sleep(2500);
          }
          if (_playerMode == PlayerMode.Training)
          {
            ModeToFixedPosition();

            SetTrainingState(true);
          }
          UpLevel();
          UseItem();
          HandleTowerTrainingUpdate();
        }
      });
    }

    private void ModeToFixedPosition()
    {
      if (_settings != null && _settings.FixedMapId == _player.MapID && (Math.Abs(_settings.FixedX - _player.PosX) > 5 || Math.Abs(_player.PosY - _settings.FixedY) > 5))
      {
        ThreadPool.QueueUserWorkItem(state1 =>
        {
          this._player.AutoAccount.CallMoveTo(_settings.FixedX, _settings.FixedY);
          Thread.Sleep(2000);
        });
      }
    }

    private void OnSettingsPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      // Handle settings changes
      if (e.PropertyName == nameof(PlayerSettings.Mode))
      {
        // Sync _playerMode with Settings.Mode
        _playerMode = _settings.Mode;

        // Update training state based on mode
        if (_playerMode == PlayerMode.Training)
        {
          SetTrainingState(true);
        }
        else if (_playerMode == PlayerMode.FightTower)
        {
          SetTrainingState(false);
          _currentPositionIndex = 0;
          _isMovingForward = true;
          Debug.WriteLine("Tower Mode Enabled - Starting ping-pong patrol");
        }
        else
        {
          SetTrainingState(false);
        }

        // Notify Mode property
        OnPropertyChanged(nameof(Mode));
      }
      // Save settings when any property changes
      SaveSettings();
    }

    public void LoadSkills()
    {
      if (_player == null || _databaseService == null)
        return;
      if (_player.Menpai != Menpais.NOMENPAI && _player.Skills.Count == 0)
      {
        try
        {
          // Load skills from database
          var skills = _databaseService.GetSkillsByMenpai(_player.Menpai.ToString());
          
          // Clear existing skills and add new ones
          _player.Skills.Clear();
          var skillIdSeleted = JsonConvert.DeserializeObject<List<int>>(_settings.SelectedSkillIdsJson);
          foreach (var skill in skills)
          {
            var newSkill = new Skill()
            {
              Id = skill.Id,
              Name = skill.Name,
              IsSelected = skillIdSeleted.Contains(skill.Id)
            };
            newSkill.PropertyChanged += HandleEventUIChange;
            _player.Skills.Add(newSkill);
          }

          // Initialize AutoAccount SkillPlayList based on selected skills
          Player.AutoAccount.Settings.SkillPlayList = new GAutoList<SkillPlayItem>();
          foreach (var item in _player.Skills.Where(s => s.IsSelected))
          {
            HandleSkillCheckedChanged(item.Id);
          }
        }
        catch (Exception ex)
        {
          // Log or handle error silently
          System.Diagnostics.Debug.WriteLine($"Error loading skills: {ex.Message}");
        }
      }
    }

    public void LoadPets()
    {
      if (_player == null || _player.AutoAccount == null || _player.AutoAccount.MyPet == null)
        return;

      try
      {
        // Get all pets with valid IDs
        var allPets = _player.AutoAccount.MyPet.AllPets.Where(p => p.DatabaseID > 0 || p.ID > 0).ToList();
        if (allPets == null || allPets.Count == 0) return;

        // Initialize Pets collection if empty
        if (_player.Pets == null || _player.Pets.Count == 0)
        {
          _player.Pets = new ObservableCollection<Pet>();
          foreach (var pet in allPets)
          {
            var newPet = new Pet()
            {
              Id = pet.DatabaseID,
              Name = !string.IsNullOrEmpty(pet.PetName) ? pet.PetName : pet.DatabaseID.ToString()
            };
            _player.Pets.Add(newPet);
          }
        }
        else
        {
          // Add new pets if they don't exist (check by DatabaseID)
          foreach (var pet in allPets)
          {
            if (!_player.Pets.Any(p => p.Id == pet.DatabaseID))
            {
              var newPet = new Pet()
              {
                Id = pet.DatabaseID,
                Name = !string.IsNullOrEmpty(pet.PetName) ? pet.PetName : pet.DatabaseID.ToString()
              };
              _player.Pets.Add(newPet);
            }
          }
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error loading pets: {ex.Message}");
      }
    }

    private void ExecuteGetCurrentPosition(object parameter)
    {
      if (_player != null && _settings != null)
      {
        _settings.FixedX = (int)_player.PosX;
        _settings.FixedY = (int)_player.PosY;
        _settings.FixedMapId = _player.MapID;
        _settings.FixedMapName = _player.MapName;
      }
    }

    private void ExecuteClearFixedPosition(object parameter)
    {
      if (_settings != null)
      {
        _settings.FixedX = 0;
        _settings.FixedY = 0;
        _settings.FixedMapId = 0;
        _settings.FixedMapName = "";
      }
    }
    private void ExecuteClearSelectedPet(object parameter)
    {
      if (_settings != null)
      {
        _settings.SelectedPetId = 0;
      }
    }

    /// <summary>
    /// Directly controls the training state in AutoAccount without changing IsTraining property.
    /// Use this method when you need to enable/disable AI training without triggering IsTraining property setter.
    /// </summary>
    /// <param name="enabled">True to enable training, false to disable</param>
    private void SetTrainingState(bool enabled)
    {
      if (_player?.AutoAccount != null && _player.AutoAccount.IsAIEnabled != enabled)
      {
        _player.AutoAccount.IsAIEnabled = enabled;
      }
    }

    private void UpLevel()
    {
      try
      {
        if (_settings.IsAutoUpLevel && _player.Level < _settings.MaxLevel)
        {
          _player.AutoAccount.CallUpLevelPacket();
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
      }
    }

    private void UseItem()
    {
      try
      {
        if (_settings == null) return;

        if (_settings.IsAutoUseX2Exp)
        {
          var itemIndex = FindItemIndexInInventoryCharacter(ItemIdState.X2ExpItemId);
          if (itemIndex != -1)
          {
            _player.AutoAccount.CallUseItem(itemIndex, _player.Id);
          }
        }

        if (_settings.IsAutoUseResetLevelItem)
        {
          var itemIndex = FindItemIndexInInventoryCharacter(ItemIdState.ResetLevelItemId);
          if (itemIndex != -1)
          {
            _player.AutoAccount.CallUseItem(itemIndex, _player.Id);
          }
        }

        if (_settings.IsAutoUseAddPointItem)
        {
          // Find add point item by ID in inventory
          var itemIndex = FindItemIndexInInventoryCharacter(ItemIdState.AddPointItemId);
          if (itemIndex != -1)
          {
            _player.AutoAccount.CallUseItem(itemIndex, _player.Id);
          }
        }

        var checkItems = Player.InventoryItems.Where(i => i.IsSelected);
        foreach (var useItem in checkItems)
        {
          var itemIndex = FindItemIndexInInventoryCharacter(useItem.Id);
          if (itemIndex != -1)
          {
            Player.AutoAccount.CallUseItem(itemIndex, Player.Id);
          }
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message.ToString());
      }
    }

    private int FindItemIndexInInventoryCharacter(int itemId)
    {
      if (_player.AutoAccount.MyInventory.AllItems == null || _player.AutoAccount.MyInventory.AllItems.Count == 0)
        return -1;
      for (int i = 0; i < _player.AutoAccount.MyInventory.AllItems.Count; i++)
      {
        if (_player.AutoAccount.MyInventory.AllItems[i].ItemID == itemId) return i;
      }
      return -1;
    }

    #region Settings Persistence

    private void SaveSettings()
    {
      if (_databaseService == null || _player == null || _settings == null)
        return;
      try
      {
        // Update JSON fields
        _settings.TowerPositionsJson = JsonConvert.SerializeObject(_towerPositions);
        _settings.SelectedSkillIdsJson = JsonConvert.SerializeObject(
          _player.Skills.Where(s => s.IsSelected).Select(s => s.Id).ToList()
        );
        _settings.CheckedItemIdsJson = JsonConvert.SerializeObject(
          _player.InventoryItems.Where(i => i.IsSelected).Select(i => i.Id).ToList()
        );

        _databaseService.SavePlayerSettings(_settings);
        Debug.WriteLine($"Settings saved for player {_player.DatabaseId}");
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error saving settings: {ex.Message}");
      }
    }
    public void LoadSettings()
    {
      if (_databaseService == null || _player == null || _player.DatabaseId <= 0 || 
        ( _player.Skills != null && _player.Skills.Count > 0))
      {
        return;
      }
      try
      {
        var loadedSettings = _databaseService.LoadPlayerSettings(_player.DatabaseId);
        if (loadedSettings != null)
        {
          // Set the Settings property with loaded data
          Settings = loadedSettings;

          // Load player mode from settings
          _playerMode = _settings.Mode;

          // Update training state based on mode
          if (_playerMode == PlayerMode.Training || _playerMode == PlayerMode.FightTower)
          {
            SetTrainingState(true);
          }
          else
          {
            SetTrainingState(false);
          }

          if (!string.IsNullOrEmpty(_settings.TowerPositionsJson))
          {
            try
            {
              var positions = JsonConvert.DeserializeObject<List<TowerPosition>>(_settings.TowerPositionsJson);
              if (positions != null && positions.Count > 0)
              {
                // Unsubscribe from old positions
                foreach (var oldPos in _towerPositions)
                {
                  oldPos.PropertyChanged -= HandleEventUIChange;
                }

                _towerPositions.Clear();
                foreach (var pos in positions)
                {
                  pos.PropertyChanged += HandleEventUIChange;
                  _towerPositions.Add(pos);
                }
              }
            }
            catch (Exception ex)
            {
              Debug.WriteLine($"Error loading tower positions: {ex.Message}");
            }
          }

          // Load checked inventory items
          if (!string.IsNullOrEmpty(_settings.CheckedItemIdsJson))
          {
            try
            {
              var itemIds = JsonConvert.DeserializeObject<List<int>>(_settings.CheckedItemIdsJson);
              if (itemIds != null && _player.InventoryItems != null)
              {
                foreach (var item in _player.InventoryItems)
                {
                  item.IsSelected = itemIds.Contains(item.Id);
                }
              }
            }
            catch (Exception ex)
            {
              Debug.WriteLine($"Error loading item selections: {ex.Message}");
            }
          }

          Debug.WriteLine($"Settings loaded for player {_player.DatabaseId}");

          // Call SetPetActive to activate the selected pet
          SetPetActive();
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error loading settings: {ex.Message}");
      }
      finally
      {
      }
    }


    /// <summary>
    /// Activates the selected pet based on SelectedPetId in settings.
    /// This method will be implemented with the logic to call the appropriate pet activation method.
    /// </summary>
    private void SetPetActive()
    {
      if (_player == null || _player.AutoAccount == null || _settings == null)
        return;

      if (_settings.SelectedPetId <= 0)
        return;

      // TODO: Implement pet activation logic
      // Find the pet by ID and call activation method
      // Example: var pet = _player.Pets.FirstOrDefault(p => p.Id == _settings.SelectedPetId);
      // if (pet != null) _player.AutoAccount.CallPetSure(pet.Name);
      Debug.WriteLine($"SetPetActive called for pet ID: {_settings.SelectedPetId}");
    }

    /// <summary>
    /// Handle all prop when UI change, assign event += for it
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleEventUIChange(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == nameof(TowerPosition.IsSelected) ||
        e.PropertyName == nameof(InventoryItem.IsSelected) || 
        e.PropertyName == nameof(Skill.IsSelected))
      {
        SaveSettings();
      }

      if (e.PropertyName == nameof(Skill.IsSelected))
      {
        Player.AutoAccount.Settings.SkillPlayList = new GAutoList<SkillPlayItem>();
        foreach (var item in Player.Skills.Where(s => s.IsSelected))
        {
          HandleSkillCheckedChanged(item.Id);
        }
      }
    }

    private void HandleSkillCheckedChanged(int skillId)
    {
      
      SkillPlayItem skillPlayItem = new SkillPlayItem();
      SingleSkill singleSkill = new SingleSkill();
      
      var skillBook = frmLogin.GAuto.SkillBookDB.FirstOrDefault(s => s.SkillID == skillId);

      singleSkill.ID = skillBook.SkillID;
      singleSkill.Name = skillBook.SkillName;
      singleSkill.Special = skillBook.Special;
      singleSkill.BookSlot = skillBook.BookSlot;
      singleSkill.BuffPeriod = skillBook.BuffPeriod;
      singleSkill.RageRequired = skillBook.RageRequired;
      singleSkill.SkillBook = skillBook.SkillBook;
      singleSkill.Special = skillBook.Special;
      skillPlayItem.SkillItem = singleSkill;
      skillPlayItem.IsEnabled = true;
      skillPlayItem.SkillDelayInSecond = 1;
      var a = skillId;
      if (skillId == 395)
      {
        a = 394;
      }

      var skill = Player.AutoAccount.MySkills.AllSkills.FirstOrDefault(s => s.ID == a);
      skillPlayItem.SkillItem.KeyDesc = skill.KeyDesc;
      Player.AutoAccount.Settings.SkillPlayList.Add(skillPlayItem);
    }
    #endregion
  }
}
