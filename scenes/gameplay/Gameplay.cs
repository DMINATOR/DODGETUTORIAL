using Godot;
using System;

public class Gameplay : Node
{
    [Export]
    public PackedScene MobScene;

    [Export]
    public AudioStream Music;

    private GameplayHUD _gameplayHUD;
    private Timer _scoreTimer;
    private AudioStreamPlayer _music;

    public override void _Ready()
    {
        _gameplayHUD = GetNode<GameplayHUD>("GameplayHUD");
        _scoreTimer = GetNode<Timer>("ScoreTimer");
        _music = GetNode<AudioStreamPlayer>("Audio/Music");

        // Reset score
        GlobalGameState.Score = 0;

        // Start playing music
        //this.GetGlobalAudioManager().PlayMusic(_music);
        this.GetGlobalAudioManager().PlayMusic(Music);
    }

    public void OnScoreTimerTimeout()
    {
        GlobalGameState.Score++;

        _gameplayHUD.UpdateScore();
    }

    public void OnPlayerHit()
    {
        // Stop counting score
        _scoreTimer.Stop();

        this.GetGlobalSceneManager().GameOver();
    }
}
