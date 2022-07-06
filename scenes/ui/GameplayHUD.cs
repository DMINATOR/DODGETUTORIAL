using Godot;
using System;

public class GameplayHUD : CanvasLayer
{
    private Label _scoreLabel;

    [Export]
    public int Score;

    public override void _Ready()
    {
        _scoreLabel = GetNode<Label>("ScoreLabel");
    }

    public void OnScoreTimerTimeout()
    {
        Score++;

        _scoreLabel.Text = Score.ToString();
    }
}
