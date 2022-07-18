using Godot;
using System;

// Audio Music player, with automatic fade In and Fade out
public class AudioMusic : Node
{
    [Export]
    public float MinVolume = -80;

    [Export]
    public float MaxVolume = 0;

    [Export]
    public float FadeDuration = 3.0f;

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
        _audioPlayer.Stream = audioStream;

        // From Min -> Max
        _tween.InterpolateProperty(_audioPlayer, "volume_db", MinVolume, MaxVolume, FadeDuration);
        _tween.Start();
        _audioPlayer.Play();
    }

    public void FadeOutAndPlay()
    {
        _tween.StopAll();

        // From (Current volume) -> Min
        _tween.InterpolateProperty(_audioPlayer, "volume_db", _audioPlayer.VolumeDb, MinVolume, FadeDuration);
        _tween.Start();
    }
}
