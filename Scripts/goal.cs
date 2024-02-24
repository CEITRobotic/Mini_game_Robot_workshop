using System;
using Godot;

public partial class goal : StaticBody3D
{
    public static Vector3 goal_position;

    public override void _Process(double delta)
    {
        goal_position = GlobalPosition;
    }
}
