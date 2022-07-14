using Godot;
using System;

// Define Scene as AutoLoader for this to work
public class GlobalSceneManager : Node
{
    [Export]
    public string GameoverScene;

    [Export]
    public string GameplayScene;

    [Export]
    public string NewGameScene;

    public void GameOver()
    {
        GetTree().ChangeScene(GameoverScene);
    }

    public void Gameplay()
    {
        GetTree().ChangeScene(GameplayScene);
    }

    public void NewGame()
    {
        GetTree().ChangeScene(NewGameScene);
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