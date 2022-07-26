using Godot;

/// <summary>
///  Loads and saves game data, see: https://docs.godotengine.org/en/stable/tutorials/io/saving_games.html
///  https://docs.godotengine.org/en/stable/classes/class_configfile.html#class-configfile
/// </summary>
public class GlobalGameStateManager : Node
{
    public const string ConfigFilePath = "user://scores.cfg";

    public override void _Ready()
    {
        base._Ready();

        LoadGame();
    }

    public void SaveGame()
    {
        // Create new ConfigFile object.
        var config = new ConfigFile();

        // Store some values.
        GlobalGameState.PersistedData.SaveToConfig(config);

        // Save it to a file (overwrite if already exists).
        config.Save(ConfigFilePath);
    }

    public void LoadGame()
    {
        var config = new ConfigFile();
        config.Load(ConfigFilePath);

        // Store some values.
        GlobalGameState.PersistedData.LoadFromConfig(config);

        // Update audio levels from config
        this.GetGlobalAudioManager().UpdateAudioLevels(GlobalGameState.PersistedData);
    }
}


public static class GlobalGameStateManagerExtensions
{
    // Retrieves an instance of a audio manager
    public static GlobalGameStateManager GetGlobalGameStateManager(this Node node)
    {
        return node.GetNode<GlobalGameStateManager>($"/root/{nameof(GlobalGameStateManager)}");
    }
}