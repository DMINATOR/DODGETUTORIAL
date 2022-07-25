using Godot;
using System;

public class OptionsHUD : Control
{
    [Signal]
    public delegate void OnBackDelegate();

    private HSlider _musicSlider;

    public override void _Ready()
    {
        base._Ready();

        _musicSlider = GetNode<HSlider>("Panel/VBoxContainer/MusicSlider");

        _musicSlider.Value = GlobalGameState.PersistedData.MusicVolumeInDb;
    }

    public void OnBackButtonPressed()
    {
        // Save changes
        this.GetGlobalGameStateManager().SaveGame();

        GetTree().Paused = false;
        EmitSignal(nameof(OnBackDelegate));
    }

    public void OnMusicSliderValueChanged(float value)
    {
        GlobalGameState.PersistedData.MusicVolumeInDb = (int)value;

        // Change actual music level
        this.GetGlobalAudioManager().UpdateAudioLevels(GlobalGameState.PersistedData);
    }
}
