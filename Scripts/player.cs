using System;
using Godot;

public partial class player : CharacterBody3D
{
    public override void _Ready()
    {
        Translate(new Vector3(1, 0, 0));
        GD.Print(Transform.Origin);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (IsOnFloor() != true)
        {
            Velocity = Vector3.Down * (float)delta * 1000;
        }
        MoveAndSlide();
    }
}
