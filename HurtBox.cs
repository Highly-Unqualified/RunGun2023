using Godot;
using System;

public class HurtBox : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public override _Init()
    {
        CollisionLayer = 0;
        CollisionMask = 2;
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        connect("AreaEntered", self, "OnAreaEntered")
    }

    public void OnAreaEntered(hitBox: HitBox)
    {
        if (hitBox == null)
        {
            return
        }

        if (owner.HasMethod("TakeDamage"))
        {
            owner.TakeDamage(hitbox.Damage);
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
