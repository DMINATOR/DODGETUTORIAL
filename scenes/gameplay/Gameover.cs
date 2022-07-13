using Godot;
using System;

public class Gameover : Node
{
    //private GameOverHUD _gameOverHUD;
    private SceneManager _sceneManager;

    public override void _Ready()
    {
        _sceneManager = GetNode<SceneManager>("SceneManager");
        //_gameOverHUD = GetNode<GameOverHUD>("GameOverHUD");

        if (_sceneManager == null) throw new Exception($"{nameof(_sceneManager)} is null!");
        //if (_gameOverHUD == null) throw new Exception($"{nameof(_gameOverHUD)} is null!");

        GD.Print($"_Ready");
    }

    public void OnStartGameButtonPressed()
    {
        _sceneManager.Gameplay();
    }
}
