using Godot;
using System;

public class OptionsHUD : VBoxContainer
{
    [Signal]
    public delegate void OnBackDelegate();

    public void OnBackButtonPressed()
    {
        EmitSignal(nameof(OnBackDelegate));
    }
}
