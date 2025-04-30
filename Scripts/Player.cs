using Godot;
using System;

public partial class Player : Area2D
{
    [Export]
    public int speed = 400;
    public Vector2 screenSize;

    public override void _Ready()
    {
        screenSize = GetViewportRect().Size;

        Position = new Vector2(screenSize.X / 2, screenSize.Y /2);
    }

    public override void _Process(double delta)
    {
        var vel = Vector2.Zero;

        if (Input.IsActionPressed("move_right"))
        {
            vel.X += 1;
        }

        if (Input.IsActionPressed("move_left"))
        {
            vel.X -= 1;
        }

        if (Input.IsActionPressed("jump"))
        {
            vel.Y -= 1;
        }

        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        if (vel.Length() > 0)
        {
            vel = vel.Normalized() * speed;
            animatedSprite2D.Play();
        }
        else
        {
            animatedSprite2D.Stop();
        }

        Position += vel * (float)delta;
        Position = new Vector2 (
            x: Mathf.Clamp(Position.X, 0, screenSize.X),
            y: Mathf.Clamp(Position.Y, 0, screenSize.Y)
        );
    }

}

