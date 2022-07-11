using Godot;
using System;

public class NewGame : Node
{
    private SceneManager _sceneManager;

    public override void _Ready()
    {
        _sceneManager = GetNode<SceneManager>("SceneManager");
    }

    public void OnStartGameButtonPressed()
    {
        _sceneManager.Gameplay();
    }
}
