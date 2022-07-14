using Godot;
using System;

public class NewGame : Node
{
    public void OnStartGameButtonPressed()
    {
        this.GetGlobalSceneManager().Gameplay();
    }
}
