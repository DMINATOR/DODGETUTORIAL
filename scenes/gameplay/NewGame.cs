using Godot;
using System;

public class NewGame : Node
{
    [Export]
    public AudioStream Music;

    public override void _Ready()
    {
        // Start playing music
        this.GetGlobalAudioManager().PlayMusic(Music);
    }

    public void OnStartGameButtonPressed()
    {
        this.GetGlobalSceneManager().Gameplay();
    }
}
