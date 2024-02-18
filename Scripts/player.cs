using System;
using Godot;

public partial class player : CharacterBody3D
{
    public string slot_text;

    private int direction = 0;
    private int x = 0;
    private int z = 0;

    public override void _Ready()
    {
        Label text_control = GetNode<Label>($"../UI/TC_MarginContainer/TextControl");
        text_control.Text = "Hello World";
    }

    public override void _PhysicsProcess(double delta)
    {
        if (IsOnFloor() != true)
        {
            Velocity = Vector3.Down * (float)delta * 1000;
        }

        rotationY((float)delta);

        GD.Print(GlobalPosition);

        MoveAndSlide();
    }

    private void rotationY(float delta)
    {
        direction = direction > 2 ? -1 : direction;
        direction = direction < -1 ? 2 : direction;

        switch (direction)
        {
            case -1:
                RotationDegrees = new Vector3(0, Mathf.Lerp(RotationDegrees.Y, -90, delta * 10), 0);

                GlobalPosition = new Vector3(
                    GlobalPosition.X,
                    GlobalPosition.Y,
                    Mathf.Lerp(GlobalPosition.Z, z, delta * 10)
                );
                break;
            case 0:
                RotationDegrees = new Vector3(0, Mathf.Lerp(RotationDegrees.Y, 0, delta * 10), 0);

                GlobalPosition = new Vector3(
                    Mathf.Lerp(GlobalPosition.X, x, delta * 10),
                    GlobalPosition.Y,
                    GlobalPosition.Z
                );
                break;
            case 1:
                RotationDegrees = new Vector3(0, Mathf.Lerp(RotationDegrees.Y, 90, delta * 10), 0);

                GlobalPosition = new Vector3(
                    GlobalPosition.X,
                    GlobalPosition.Y,
                    Mathf.Lerp(GlobalPosition.Z, z, delta * 10)
                );
                break;
            case 2:
                RotationDegrees = new Vector3(0, Mathf.Lerp(RotationDegrees.Y, 180, delta * 10), 0);

                GlobalPosition = new Vector3(
                    Mathf.Lerp(GlobalPosition.X, x, delta * 10),
                    GlobalPosition.Y,
                    GlobalPosition.Z
                );
                break;
        }
    }

    private void _on_rotate_left_button_pressed()
    {
        direction++;
    }

    private void _on_forward_button_pressed()
    {
        switch (direction)
        {
            case -1:
                z++;
                break;
            case 0:
                x++;
                break;
            case 1:
                z--;
                break;
            case 2:
                x--;
                break;
        }
    }

    private void _on_rotate_right_button_pressed()
    {
        direction--;
    }

    private void _on_play_pressed() { }
}
