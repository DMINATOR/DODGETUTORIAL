using Godot;
using System;

public class Gameplay : Node
{
    [Export]
    public PackedScene MobScene;

    public int Score;

    public void OnScoreTimerTimeout()
    {
        Score++;

        GetNode<GameplayHUD>("GameplayHUD").UpdateScore(Score);
    }
}
