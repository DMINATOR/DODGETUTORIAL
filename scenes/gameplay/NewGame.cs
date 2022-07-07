using Godot;
using System;

public class NewGame : Node
{
    [Export]
    public PackedScene GameplayScene;

    public void OnStartGameButtonPressed()
    {
        GetTree().ChangeSceneTo(GameplayScene);
    }
}
