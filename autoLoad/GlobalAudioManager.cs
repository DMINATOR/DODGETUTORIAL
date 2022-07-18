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
    // Folders to store child nodes
    Node _musicFolder;
    Node _soundsFolder;

    [Export]
    public PackedScene AudioMusicScene;

    // Currently playing music
    AudioMusic _currentMusic;

    List<AudioMusic> _expiredMusic = new List<AudioMusic>();

    public override void _Ready()
    {
        _musicFolder = GetNode<Node>("Music");
        _soundsFolder = GetNode<Node>("Sounds");
    }

    public void PlayMusic(AudioStream audioStream)
    {
        if ( _currentMusic != null )
        {
            // Expire current music
            _expiredMusic.Add(_currentMusic);
        }

        _currentMusic = AudioMusicScene.Instance<AudioMusic>();
        _musicFolder.AddChild(_currentMusic);

        // Start playing
        _currentMusic.FadeInAndPlay(audioStream);
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