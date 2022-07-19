using Godot;
using System;

// Audio Music player, with automatic fade In and Fade out
public class AudioMusic : Node
{
    [Signal]
    public delegate void OnFadeOut(AudioMusicFadeOutMode fadeOutMode, AudioMusic instance);

    [Export]
    public float MinVolume = -80;

    [Export]
    public float MaxVolume = 0;

    [Export]
    public float FadeDuration = 3.0f;

    AudioMusicFadeOutMode _audioMusicFadeOutMode;
    AudioStreamPlayer _audioPlayer;
    Tween _tween;

    public override void _Ready()
    {
        base._Ready();

        _audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        _tween = GetNode<Tween>("Tween");
    }

    public void FadeInAndPlay(AudioStream audioStream)
    {
        _audioMusicFadeOutMode = AudioMusicFadeOutMode.FadeIn;
        _audioPlayer.Stream = audioStream;

        // From Min -> Max
        _tween.InterpolateProperty(_audioPlayer, "volume_db", MinVolume, MaxVolume, FadeDuration);
        _tween.Start();
        _audioPlayer.Play();
    }

    public void FadeOutAndPlay()
    {
        _audioMusicFadeOutMode = AudioMusicFadeOutMode.FadeOut;
        _tween.StopAll();

        // From (Current volume) -> Min
        _tween.InterpolateProperty(_audioPlayer, "volume_db", _audioPlayer.VolumeDb, MinVolume, FadeDuration);
        _tween.Start();
    }

    public void OnTweenAllCompleted()
    {
        GD.Print("completed");

        // Trigger completed event:
        EmitSignal(nameof(OnFadeOut), _audioMusicFadeOutMode, this);
    }
}

public enum AudioMusicFadeOutMode
{
    FadeIn,
    FadeOut
}