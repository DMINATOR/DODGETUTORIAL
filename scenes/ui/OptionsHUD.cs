using Godot;
using System;

public class OptionsHUD : Control
{
    [Signal]
    public delegate void OnBackDelegate();

    public void OnBackButtonPressed()
    {
        EmitSignal(nameof(OnBackDelegate));
    }
}
