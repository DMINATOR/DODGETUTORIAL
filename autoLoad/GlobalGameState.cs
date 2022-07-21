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
    // Music volume, expected in range -80..20, default = 0
    public int MusicVolumeInDb = 0;
}

