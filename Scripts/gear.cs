using System;
using Godot;

public partial class gear : Area3D
{
	public static Vector3 gear_position;
	private float d;
	private AudioStreamPlayer sound;

	public override void _Ready()
	{
		sound = GetNode<AudioStreamPlayer>($"../CollectGear");
	}

	public override void _Process(double delta)
	{
		d += (float)delta;

		RotationDegrees = new Vector3(RotationDegrees.X, d * 50, RotationDegrees.Z);

		if (
			GlobalPosition.X == Mathf.Round(player.player_position.X)
			&& GlobalPosition.Z == Mathf.Round(player.player_position.Z)
		)
		{
			sound.Playing = true;
			player.score += 100;
			GD.Print("Delete Gear");
			Free();
		}
	}
}
