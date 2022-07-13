using Godot;
using System;

public class GameOverHUD : CanvasLayer
{
    [Signal]
    public delegate void StartGameButtonPressed();

    private Button _startButton;
    private Label _scoreLabel;

    public override void _Ready()
    {
        base._Ready();

        _startButton = GetNode<Button>("StartButton");
        _scoreLabel = GetNode<Label>("ScoreLabel");

        _scoreLabel.Text = GlobalGameState.Score.ToString();
    }

    public void OnStartButtonPressed()
    {
        EmitSignal(nameof(StartGameButtonPressed));
    }
}
