using Godot;
using System;

public class SceneManager : Node
{
    [Export]
    public string GameoverScene;
    private PackedScene _gameoverScene;

    [Export]
    public string GameplayScene;

    [Export]
    public string NewGameScene;



    public override void _Ready()
    {
        _gameoverScene = GD.Load<PackedScene>(GameoverScene);
    }

    public void GameOver()
    {
        GetTree().ChangeSceneTo(_gameoverScene);
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
