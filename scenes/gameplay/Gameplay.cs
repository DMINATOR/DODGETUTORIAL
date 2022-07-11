using Godot;
using System;

public class Gameplay : Node
{
    [Export]
    public PackedScene MobScene;

    [Export]
    public PackedScene GameoverScene;

    public int Score;

    private GameplayHUD _gameplayHUD;

    public override void _Ready()
    {
        _gameplayHUD = GetNode<GameplayHUD>("GameplayHUD");
    }

    public void OnScoreTimerTimeout()
    {
        Score++;

        _gameplayHUD.UpdateScore(Score);
    }

    public void OnPlayerHit()
    {
        // Game ends when player hits
        GetTree().ChangeSceneTo(GameoverScene);
    }
}
