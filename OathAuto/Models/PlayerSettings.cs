using System.Collections.Generic;

namespace OathAuto.Models
{
  public class PlayerSettings
  {
    public int PlayerId { get; set; }

    // Training Settings
    public bool IsTraining { get; set; }
    public bool IsAutoUpLevel { get; set; }
    public bool IsAutoUseX2Exp { get; set; }
    public int MaxLevel { get; set; }
    public int ResetLevelItemIndex { get; set; }
    public int AddPointItemIndex { get; set; }
    public int FixedX { get; set; }
    public int FixedY { get; set; }
    public int FixedMapId { get; set; }
    public string FixedMapName { get; set; }
    public bool UseItemWithoutTraining { get; set; }

    // Tower Settings
    public bool IsTowerMode { get; set; }
    public bool IsAutoMoveEnabled { get; set; }
    public string TowerPositionsJson { get; set; } // JSON serialized list of TowerPosition

    // Skill Settings
    public string SelectedSkillIdsJson { get; set; } // JSON serialized list of checked skill IDs

    // Inventory Item Settings
    public string CheckedItemIndexesJson { get; set; } // JSON serialized list of checked item indexes
  }
}
