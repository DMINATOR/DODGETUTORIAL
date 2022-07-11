using Godot;
using System;

public class Gameover : Node
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
