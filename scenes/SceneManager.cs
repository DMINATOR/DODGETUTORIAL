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

    public void GameOver(int score)
    {
        // Create new instance
        var gameOverScene = _gameoverScene.Instance<Gameover>();

        // Init manually
        gameOverScene._Ready();

        // Set score
        gameOverScene.SetScore(score);

        //gameOverScene.CallDeferred(nameof(Gameover.SetScore), score); // deferred

        GetTree().ChangeSceneTo(_gameoverScene);

        //gameOverScene.SetScore(score);

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
