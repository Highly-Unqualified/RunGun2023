using Godot;
using System;

public class Player : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	// Export tag exposes to the editor
	[Export]
	public float speed = 275.00F;
	[Export]
	public float jumpStrength = 700F;
	[Export]
	public float doubleJumpStrength = 800.00F;
	[Export]
	public float gravity = 3800.00F;
	[Export]
	public int maximumJumps = 2;

	public Vector2 UP_DIRECTION = Vector2.Up;

	public Vector2 screenSize; // Size of the game window.

	public int jumpsMade = 0;
	public Vector2 _velocity = Vector2.Zero;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		screenSize = GetViewportRect().Size;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		var horizontalDirection = Input.GetActionStrength("moveRight") - Input.GetActionStrength("moveLeft");

		_velocity.x = horizontalDirection * speed;
		_velocity.y += gravity * delta;

		var isFalling = _velocity.y > 0.0 && !IsOnFloor();
		var isJumping = Input.IsActionJustPressed("jump") && IsOnFloor();
		var isDoubleJumping = Input.IsActionJustPressed("jump") && !IsOnFloor();
		var isJumpCancelled = Input.IsActionJustPressed("jump") && _velocity.y < 0.0;
		var isIdling = IsOnFloor() && Mathf.IsZeroApprox(_velocity.x);
		var isRunning = IsOnFloor() && !Mathf.IsZeroApprox(_velocity.x);

		if (isJumping)
		{
			jumpsMade += 1;
			_velocity.y -= jumpStrength;
		}
		else if (isDoubleJumping)
		{
			jumpsMade += 1;
			if (jumpsMade <= maximumJumps) {
				_velocity.y = -doubleJumpStrength;
			}
		}
		else if (isJumpCancelled)
		{
			_velocity.y = 0.0F;
		}
		else if (isIdling || isRunning)
		{
			jumpsMade = 0;
		}

		_velocity = MoveAndSlide(_velocity, UP_DIRECTION);
	}
}
