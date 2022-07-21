using Godot;
using System;

public class Gameplay : Node
{
    [Export]
    public PackedScene MobScene;

    [Export]
    public AudioStream Music;

    private GameplayHUD _gameplayHUD;
    private OptionsHUD _optionsHUD;

    private Timer _scoreTimer;

    public override void _Ready()
    {
        _gameplayHUD = GetNode<GameplayHUD>("HUD/GameplayHUD");
        _optionsHUD = GetNode<OptionsHUD>("HUD/OptionsHUD");

        _scoreTimer = GetNode<Timer>("Game/ScoreTimer");

        // Reset score
        GlobalGameState.GameplayData.Score = 0;

        // Start playing music
        this.GetGlobalAudioManager().PlayMusic(Music);
    }

    public void OnScoreTimerTimeout()
    {
        GlobalGameState.GameplayData.Score++;

        _gameplayHUD.UpdateScore();
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_cancel"))
        {
            GetTree().Paused = true;
            _optionsHUD.Visible = true;
            _gameplayHUD.Visible = false;
        }
    }

    public void OnOptionsMenuBackDelegateCallback()
    {
        _gameplayHUD.Visible = true;
        _optionsHUD.Visible = false;
        GetTree().Paused = false;
    }

    public void OnPlayerHit()
    {
        // Stop counting score
        _scoreTimer.Stop();

        this.GetGlobalSceneManager().GameOver();
    }
}
