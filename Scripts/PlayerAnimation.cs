using Godot;
using System;

public partial class PlayerAnimation : Area2D
{
    public override void _Ready()
    {
        var screenSize = GetViewportRect().Size;
        var player = this;

        player.Position = new Vector2(screenSize.X / 2, screenSize.Y / 2);

        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        animatedSprite2D.Play();
    }

}
