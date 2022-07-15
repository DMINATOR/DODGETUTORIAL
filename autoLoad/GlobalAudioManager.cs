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
    List<AudioStreamPlayer> _music;

    public override void _Ready()
    {
        GD.Print( $"Path is = {GetPath()}");

    }

    public void PlayMusic(AudioStream music)
    {
        var newMusic = new AudioStreamPlayer();
        newMusic.Stream = music;
        newMusic.Play();

        AddChild(newMusic);
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