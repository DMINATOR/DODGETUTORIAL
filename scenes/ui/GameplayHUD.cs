using Godot;
using System;

public class GameplayHUD : VBoxContainer
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
