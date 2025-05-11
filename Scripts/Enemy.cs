using Godot;
using System;
using System.Diagnostics;

public partial class Enemy : Area2D
{
    public Vector2 screenSize;

    public override void _Ready()
    {
        screenSize = GetViewportRect().Size;

        Position = new Vector2(screenSize.X / 3 * 2, screenSize.Y /2);

        Debug.WriteLine("Enemy Ready");
    }

    public override void _Process(double delta)
    {
        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        animatedSprite2D.Animation = "Idle";
        animatedSprite2D.Play();
    }
}
