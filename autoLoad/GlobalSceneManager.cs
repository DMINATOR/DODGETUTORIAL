using Godot;
using System;

// Define Scene as AutoLoader for this to work
public class GlobalSceneManager : Node
{
    [Export]
    public PackedScene GameoverScene;

    [Export]
    public PackedScene GameplayScene;

    [Export]
    public PackedScene NewGameScene;

    public void GameOver()
    {
        GetTree().ChangeSceneTo(GameoverScene);
    }

    public void Gameplay()
    {
        GetTree().ChangeSceneTo(GameplayScene);
    }

    public void NewGame()
    {
        GetTree().ChangeSceneTo(NewGameScene);
    }
}

public static class GlobalSceneManagerExtensions
{
    // Retrieves an instance of a scene manager
    public static GlobalSceneManager GetGlobalSceneManager(this Node node)
    {
        return node.GetNode<GlobalSceneManager>($"/root/{nameof(GlobalSceneManager)}");
    }
}