using Godot;
using System;
using System.Diagnostics;

public partial class Player : Area2D
{
    [Export]
    public int speed = 400;
    public Vector2 screenSize;

    public override void _Ready()
    {
        screenSize = GetViewportRect().Size;

        Position = new Vector2(screenSize.X / 3, screenSize.Y / 2);

        Debug.WriteLine("Player Ready");
    }

    public override void _Process(double delta)
    {
        var vel = Vector2.Zero;

        if (Input.IsActionPressed("move_right"))
        {
            vel = MoveRight(vel);
        }

        if (Input.IsActionPressed("move_left"))
        {
            vel = MoveLeft(vel);
        }

        if (Input.IsActionPressed("move_up"))
        {
            vel = MoveUp(vel);
        }

        if (Input.IsActionPressed("move_down"))
        {
            vel = MoveDown(vel);
        }

        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        animatedSprite2D.Play();

        if (vel.Length() > 0)
        {
            animatedSprite2D.Animation = "Walk";
            vel = vel.Normalized() * speed;
        }
        else
        {
            animatedSprite2D.Animation = "Idle";
        }

        MovePlayer(vel, delta);
    }

    public Vector2 MoveUp(Vector2 vel) 
    {
        vel.Y -= 1;
        return vel;
    }

    public Vector2 MoveDown(Vector2 vel) 
    {
        vel.Y += 1;
        return vel;
    }

    public Vector2 MoveLeft(Vector2 vel) 
    {
        vel.X -= 1;
        return vel;
    }
    public Vector2 MoveRight(Vector2 vel) 
    {
        vel.X += 1;
        return vel;
    }

    public void MovePlayer(Vector2 vel, double delta) 
    {
        Position += vel * (float)delta;
        Position = new Vector2 (
            x: Mathf.Clamp(Position.X, 0, screenSize.X),
            y: Mathf.Clamp(Position.Y, 0, screenSize.Y)
        );
    }
}