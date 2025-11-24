namespace OathAuto.Models
{
  /// <summary>
  /// Represents the current operational mode of the player
  /// </summary>
  public enum PlayerMode
  {
    /// <summary>
    /// Player is idle, not performing any automated actions
    /// </summary>
    None = 0,

    /// <summary>
    /// Player is in training mode, auto-fighting and leveling up
    /// </summary>
    Training = 1,

    /// <summary>
    /// Player is in tower mode, moving between positions and fighting
    /// </summary>
    FightTower = 2
  }
}
