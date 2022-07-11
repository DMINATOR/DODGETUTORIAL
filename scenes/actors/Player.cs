using Godot;
using System;

public class Player : Area2D
{
    [Export]
    public int Speed = 400; // How fast the player will move (pixels/sec).

    public Vector2 ScreenSize; // Size of the game window.

    private AnimatedSprite _animatedSprited;
    private Position2D _startPosition2D;
    private AudioStreamPlayer _audioDeathSound;
    private CollisionShape2D _collisionShape2D;

    [Signal]
    public delegate void Hit();

    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;

        _animatedSprited = GetNode<AnimatedSprite>("AnimatedSprite");
        _startPosition2D = GetNode<Position2D>("StartPosition");
        _audioDeathSound = GetNode<AudioStreamPlayer>("Audio/DeathSound");
        _collisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");

        Position = _startPosition2D.Position;
    }

    public override void _Process(float delta)
    {
        var velocity = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed("move_right"))
        {
            velocity.x += 1;
        }

        if (Input.IsActionPressed("move_left"))
        {
            velocity.x -= 1;
        }

        if (Input.IsActionPressed("move_down"))
        {
            velocity.y += 1;
        }

        if (Input.IsActionPressed("move_up"))
        {
            velocity.y -= 1;
        }

        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
            _animatedSprited.Play();
        }
        else
        {
            _animatedSprited.Stop();
        }

        // Change
        Position += velocity * delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.x, 0, ScreenSize.x),
            y: Mathf.Clamp(Position.y, 0, ScreenSize.y)
        );

        // Update animation
        if (velocity.x != 0)
        {
            _animatedSprited.Animation = "walk";
        }
        else if (velocity.y != 0)
        {
            _animatedSprited.Animation = "up";
        }

        if (velocity.x < 0)
        {
            _animatedSprited.FlipH = true;
        }
        else
        {
            _animatedSprited.FlipH = false;
        }

        if (velocity.y > 0)
        {
            _animatedSprited.FlipV = true;
        }
        else
        {
            _animatedSprited.FlipV = false;
        }
    }

    public void OnPlayerBodyEntered(PhysicsBody2D body)
    {
        // Play hit
        _audioDeathSound.Play();

        EmitSignal(nameof(Hit));

        // Must be deferred as we can't change physics properties on a physics callback.
        _collisionShape2D.SetDeferred("disabled", true);

        // Must be deferred as we can't change physics properties on a physics callback.
        //GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", true);
    }

    //public void Start(Vector2 pos)
    //{
    //    Position = pos;
    //    Show();
    //    GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
    //}
}
