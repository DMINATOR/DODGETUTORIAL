using Godot;
using System;

public class MobSpawner : Node
{
    // Mob to Spawn
    [Export]
    public PackedScene MobScene;

    private PathFollow2D _mobSpawnLocation;
    private Timer _mobSpawnTimer;

    public override void _Ready()
    {
        base._Ready();

        _mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
        _mobSpawnTimer = GetNode<Timer>("MobTimer");

        StartSpawningMobs();
    }

    public void StartSpawningMobs()
    {
        _mobSpawnTimer.Start();
    }

    public void StopSpawningMobs()
    {
        _mobSpawnTimer.Stop();
    }

    public void OnMobTimerTimeout()
    {
        // Note: Normally it is best to use explicit types rather than the `var`
        // keyword. However, var is acceptable to use here because the types are
        // obviously Mob and PathFollow2D, since they appear later on the line.

        // Create a new instance of the Mob scene.
        var mob = (Mob)MobScene.Instance();

        // Choose a random location on Path2D.
        _mobSpawnLocation.Offset = GD.Randi();

        // Set the mob's direction perpendicular to the path direction.
        float direction = _mobSpawnLocation.Rotation + Mathf.Pi / 2;

        // Set the mob's position to a random location.
        mob.Position = _mobSpawnLocation.Position;

        // Add some randomness to the direction.
        direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
        mob.Rotation = direction;

        // Choose the velocity.
        var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
        mob.LinearVelocity = velocity.Rotated(direction);

        // Spawn the mob by adding it to the Main scene.
        AddChild(mob);
    }
}
