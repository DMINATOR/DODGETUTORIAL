using Godot;
using System;

public class GameplayHUD : CanvasLayer
{
    private Label _scoreLabel;

    public override void _Ready()
    {
        _scoreLabel = GetNode<Label>("ScoreLabel");
    }
    public void UpdateScore()
    {
        _scoreLabel.Text = GlobalGameState.Score.ToString();
    }
}
