using Godot;
using System;

public class Gameover : Node
{
    private GameOverHUD _gameOverHUD;
    private SceneManager _sceneManager;

    public override void _Ready()
    {
        _sceneManager = GetNode<SceneManager>("SceneManager");
        _gameOverHUD = GetNode<GameOverHUD>("GameOverHUD");
    }

    public void SetScore(int score)
    {
        _gameOverHUD.SetScore(score);
    }

    public void OnStartGameButtonPressed()
    {
        _sceneManager.Gameplay();
    }
}
