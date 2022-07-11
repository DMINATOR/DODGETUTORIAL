using Godot;
using System;

public class Gameplay : Node
{
    [Export]
    public PackedScene MobScene;

    public int Score;

    private GameplayHUD _gameplayHUD;

    private SceneManager _sceneManager;

    private Timer _scoreTimer;

    public override void _Ready()
    {
        _gameplayHUD = GetNode<GameplayHUD>("GameplayHUD");
        _sceneManager = GetNode<SceneManager>("SceneManager");
        _scoreTimer = GetNode<Timer>("ScoreTimer");
    }

    public void OnScoreTimerTimeout()
    {
        Score++;

        _gameplayHUD.UpdateScore(Score);
    }

    public void OnPlayerHit()
    {
        _scoreTimer.Stop();

        _sceneManager.GameOver();
    }
}
