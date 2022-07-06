using Godot;
using System;

public class GameOverHUD : CanvasLayer
{
    [Signal]
    public delegate void StartGameButtonPressed();

    private Button _startButton;

    public override void _Ready()
    {
        base._Ready();

        _startButton = GetNode<Button>("StartButton");
    }

    public void OnStartButtonPressed()
    {
        EmitSignal(nameof(StartGameButtonPressed));
    }
}
