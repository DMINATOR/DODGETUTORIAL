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

    public void GameOver(int score)
    {
        var nextScene = (PackedScene)GD.Load(GameoverScene);
        // nextScene.NativeInstance
        var gameOverScene = nextScene.Instance<Gameover>();
        gameOverScene.SetScore(score);

        GetTree().ChangeSceneTo(nextScene);

        //var nextScene = ResourceLoader.Load<Gameover>(GameoverScene);
        //nextScene.SetScore(score);

        //GetTree().ChangeSceneTo(nextScene);
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
