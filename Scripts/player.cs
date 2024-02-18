using System;
using Godot;

public partial class player : CharacterBody3D
{
    public string slot_text;

    private int direction = 0;
    private bool _isForward = false;
    private int x = 0;

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
        GD.Print(direction);

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
                break;
            case 0:
                GlobalPosition = new Vector3(
                    Mathf.Lerp(GlobalPosition.X, x, delta * 10),
                    GlobalPosition.Y,
                    GlobalPosition.Z
                );
                RotationDegrees = new Vector3(0, Mathf.Lerp(RotationDegrees.Y, 0, delta * 10), 0);
                break;
            case 1:
                RotationDegrees = new Vector3(0, Mathf.Lerp(RotationDegrees.Y, 90, delta * 10), 0);
                break;
            case 2:
                RotationDegrees = new Vector3(0, Mathf.Lerp(RotationDegrees.Y, 180, delta * 10), 0);
                break;
        }
    }

    private void _on_rotate_left_button_pressed()
    {
        direction++;
    }

    private void _on_forward_button_pressed()
    {
        if (direction == 0)
        {
            x++;
        }
        else if (direction == 2)
        {
            x--;
        }
    }

    private void _on_backward_button_pressed()
    {
        // Replace with function body.
    }

    private void _on_rotate_right_button_pressed()
    {
        direction--;
    }

    private void _on_play_pressed() { }
}
