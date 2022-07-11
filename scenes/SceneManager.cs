using Godot;
using System;

public class SceneManager : Node
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
