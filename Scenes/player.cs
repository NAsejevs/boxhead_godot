using Godot;
using System;

public class player : KinematicBody
{
	public Vector3 velocity;
	
	public override void _Ready()
	{
	
	}

	public override void _Process(float delta)
	{
		
	}
	
	public override void _PhysicsProcess(float delta)
	{
		// We create a local variable to store the input direction.
		var direction = Vector3.Zero;

		// We check for each move input and update the direction accordingly
		if (Input.IsActionPressed("move_right"))
		{
			direction.x += 1f;
		}
		if (Input.IsActionPressed("move_left"))
		{
			direction.x -= 1f;
		}
		if (Input.IsActionPressed("move_back"))
		{
			// Notice how we are working with the vector's x and z axes.
			// In 3D, the XZ plane is the ground plane.
			direction.z += 1f;
		}
		if (Input.IsActionPressed("move_forward"))
		{
			direction.z -= 1f;
		}
		
		if (direction != Vector3.Zero)
		{
			direction = direction.Normalized();
			GetNode<Spatial>("Pivot").LookAt(Translation + direction, Vector3.Up);
		}
		
		  // Ground velocity
		velocity.x = direction.x * Speed;
		velocity.z = direction.z * Speed;
		// Moving the character
		velocity = MoveAndSlide(_velocity, Vector3.Up);
	}
}
