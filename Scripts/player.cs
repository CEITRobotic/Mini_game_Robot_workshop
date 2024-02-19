using System;
using Godot;

public partial class player : CharacterBody3D
{
    public string slot_text;
    private Label text_control;

    private int x = 0;
    private int z = 0;

    private float rotate_value = 0f;
    private bool isPlay = false;

    public override void _Ready()
    {
        text_control = GetNode<Label>($"../UI/TC_MarginContainer/TextControl");
    }

    public override void _PhysicsProcess(double delta)
    {
        text_control.Text = slot_text;

        if (IsOnFloor() != true)
        {
            Velocity = Vector3.Down * (float)delta * 1000;
        }

        startSimulation((float)delta);

        if (isPlay != false)
        {
            calculateControlling();
            isPlay = false;
        }

        /* GD.Print(RotationDegrees); */
        /* GD.Print(rotate_value); */

        MoveAndSlide();
    }

    private void startSimulation(float delta)
    {
        rotate_value %= 360f;

        RotationDegrees = new Vector3(RotationDegrees.X, rotate_value, RotationDegrees.Z);

        GlobalPosition = new Vector3(
            GlobalPosition.X,
            GlobalPosition.Y,
            Mathf.Lerp(GlobalPosition.Z, z, delta * 10)
        );

        GlobalPosition = new Vector3(
            Mathf.Lerp(GlobalPosition.X, x, delta * 10),
            GlobalPosition.Y,
            GlobalPosition.Z
        );
    }

    private async void calculateControlling()
    {
        string[] words_control = slot_text.Split(' ');
        foreach (string control in words_control)
        {
            switch (control)
            {
                case "Left":
                    rotate_value += 90f;
                    break;
                case "Right":
                    rotate_value -= 90f;
                    break;
                case "Forward":
                    if (Mathf.Abs(rotate_value) == 0)
                    {
                        x++;
                    }
                    else if (Mathf.Abs(rotate_value) == 180)
                    {
                        x--;
                    }
                    else if (rotate_value == 90 || rotate_value == -270)
                    {
                        z--;
                    }
                    else if (rotate_value == 270 || rotate_value == -90)
                    {
                        z++;
                    }
                    break;
            }
            await ToSignal(GetTree().CreateTimer(0.5f), "timeout");
        }
    }

    private void _on_rotate_left_button_pressed()
    {
        slot_text += "Left ";
    }

    private void _on_forward_button_pressed()
    {
        slot_text += "Forward ";
    }

    private void _on_rotate_right_button_pressed()
    {
        slot_text += "Right ";
    }

    private void _on_play_pressed()
    {
        isPlay = true;
    }
}
