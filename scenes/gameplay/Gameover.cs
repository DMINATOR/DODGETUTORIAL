using Godot;
using System;

public class Gameover : Node
{
    public void OnStartGameButtonPressed()
    {
        this.GetGlobalSceneManager().Gameplay();
    }
}
