using Godot;
using System;

public class GameOverHUD : CanvasLayer
{
    [Signal]
    public delegate void StartGameButtonPressed();

    private Button _startButton;
    //private Label _scoreLabel;

    public Label ScoreLabel => GetNode<Label>("ScoreLabel");

    public override void _Ready()
    {
        base._Ready();

        _startButton = GetNode<Button>("StartButton");
        //_scoreLabel = GetNode<Label>("ScoreLabel");

        //if (_startButton == null) throw new Exception($"{nameof(_startButton)} is null!");
        //if (_scoreLabel == null) throw new Exception($"{nameof(_scoreLabel)} is null!");

        //GD.Print($"ready = {ScoreLabel.Text}, {this.GetHashCode()}");
        ScoreLabel.Text = GlobalGameState.Score.ToString();
    }

    public void OnStartButtonPressed()
    {
        EmitSignal(nameof(StartGameButtonPressed));
    }

    //public void SetScore(int score)
    //{
    //    GD.Print($"setscoreh = {score}, {this.GetHashCode()}");
    //    ScoreLabel.Text = "XXX";// score.ToString();
    //}
}
