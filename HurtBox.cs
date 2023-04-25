using Godot;
using System;

public class HurtBox : Area2D
{
    // could be altered based on the weapon or owner of the hurtbox
    [Export]
    public int Damage = 20;

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
            owner.TakeDamage(Damage);
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
