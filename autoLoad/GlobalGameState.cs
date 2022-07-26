using Godot;
using System;

public class GlobalGameState : Node
{
    // Game state during runtime
    public static GameplayData GameplayData = new GameplayData();

    // Game state to persist
    public static PersistedData PersistedData = new PersistedData();
}

public class GameplayData
{
    public int Score;
}

public class PersistedData
{
    // Music volume, expected in range -80..0, default = 0
    public int MusicVolumeInDb = 0;

    // Music volume, expected in range -80..0, default = 0
    public int SoundVolumeInDb = 0;

    public void SaveToConfig(ConfigFile config)
    {
        config.SetValue(nameof(PersistedData), nameof(MusicVolumeInDb), MusicVolumeInDb);
        config.SetValue(nameof(PersistedData), nameof(SoundVolumeInDb), SoundVolumeInDb);
    }

    public void LoadFromConfig(ConfigFile config)
    {
        MusicVolumeInDb = (int)config.GetValue(nameof(PersistedData), nameof(MusicVolumeInDb), 0);
        SoundVolumeInDb = (int)config.GetValue(nameof(PersistedData), nameof(SoundVolumeInDb), 0);
    }
}

