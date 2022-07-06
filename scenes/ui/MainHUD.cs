using Godot;
using System;

public class MainHUD : CanvasLayer
{
    public enum GameMode
    {
        NewGame,
        Gameplay,
        GameOver
    }

    [Export]
    public PackedScene GameplayHUD;

    [Export]
    public PackedScene NewGameHUD;

    [Export]
    public PackedScene GameOverHUD;

    // Current mode
    [Export]
    public GameMode CurrentGameMode;


    private PackedScene _currentHUD;

    private Node _currentHUDInstance = null;

    public override void _Ready()
    {
        ShowHud(CurrentGameMode);
    }

    public void ShowHud(GameMode gameMode)
    {
        if(_currentHUDInstance != null )
        {
            // destroy
            RemoveChild(_currentHUDInstance);
        }

        switch(gameMode)
        {
            case GameMode.NewGame:
                _currentHUD = NewGameHUD;
                break;

            case GameMode.Gameplay:
                _currentHUD = GameplayHUD;
                break;

            case GameMode.GameOver:
                _currentHUD = GameOverHUD;
                break;

            default:
                throw new Exception($"Unknown game mode {gameMode}");
        }

        _currentHUDInstance = _currentHUD.Instance();
        AddChild(_currentHUDInstance);
    }
}
