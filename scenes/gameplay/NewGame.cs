using Godot;
using System;

public class NewGame : Node
{
    [Export]
    public AudioStream Music;

    public override void _Ready()
    {
        //_music = GetNode<AudioStreamPlayer>("Audio/Music");

        // Start playing music
        this.GetGlobalAudioManager().PlayMusic(Music);
    }

    public void OnStartGameButtonPressed()
    {
        this.GetGlobalSceneManager().Gameplay();
    }
}
