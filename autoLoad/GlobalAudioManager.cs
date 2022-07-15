using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

/// <summary>
/// 
/// See: https://docs.godotengine.org/en/stable/tutorials/audio/audio_streams.html
/// </summary>
public class GlobalAudioManager : Node
{
    // Currently playing music
    AudioStreamPlayer _currentMusic;

    // Music that is expired and has to fade out
    List<AudioStreamPlayer> _expiredMusic = new List<AudioStreamPlayer>();

    // Folders to store child nodes
    Node _music;
    Node _sounds;

    // Timer to apply sounds effects
    Timer _musicFadeInOutTimer;

    private const float MinVolume = -80;
    private const float MaxVolume = 0;
    private const float IncreaseByStep = 10;

    public override void _Ready()
    {
        _music = GetNode<Node>("Music");
        _sounds = GetNode<Node>("Sounds");
        _musicFadeInOutTimer = GetNode<Timer>("MusicFadeInOutTimer");
    }

    public void PlayMusic(AudioStream audioStream)
    {
        var newMusic = CreateAudioStreamPlayer(audioStream);
        _music.AddChild(newMusic);

        if ( _currentMusic != null )
        {
            // Expire current music
            _expiredMusic.Add(_currentMusic);
        }

        // Start playing
        _currentMusic = newMusic;
        _currentMusic.VolumeDb = MinVolume;
        _currentMusic.Play();

        CheckTimer();
    }

    private void CheckTimer()
    {
        //var shouldPause = _expiredMusic.Count == 0 && _currentMusic == null;

        //GD.Print($"Timer {_musicFadeInOutTimer.Paused} -> {shouldPause}");

        //_musicFadeInOutTimer.Paused = shouldPause;
    }

    private AudioStreamPlayer CreateAudioStreamPlayer(AudioStream audioStream)
    {
        return new AudioStreamPlayer
        {
            Stream = audioStream
        };
    }

    public void MusicFadeInOutTimerTimeout()
    {
        // Increase current music volume
        if( _currentMusic.VolumeDb < MaxVolume )
        {
            GD.Print($"Volume {_currentMusic.VolumeDb} -> +{IncreaseByStep}");

            _currentMusic.VolumeDb += IncreaseByStep;
        }

        CheckTimer();
    }
}

public static class GlobalAudioManagerExtensions
{
    // Retrieves an instance of a audio manager
    public static GlobalAudioManager GetGlobalAudioManager(this Node node)
    {
        return node.GetNode<GlobalAudioManager>($"/root/{nameof(GlobalAudioManager)}");
    }
}