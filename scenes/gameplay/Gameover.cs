using Godot;
using System;

public class Gameover : Node
{
    [Export]
    public PackedScene GameplayScene;

    public void OnStartGameButtonPressed()
    {
        GetTree().ChangeSceneTo(GameplayScene);
    }
}
