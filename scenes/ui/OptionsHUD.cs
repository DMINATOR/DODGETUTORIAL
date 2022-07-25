using Godot;
using System;

public class OptionsHUD : Control
{
    [Signal]
    public delegate void OnBackDelegate();

    private HSlider _musicSlider;
    private HSlider _soundlider;

    public override void _Ready()
    {
        base._Ready();

        _musicSlider = GetNode<HSlider>("Panel/VBoxContainer/MusicSlider");
        _musicSlider.Value = GlobalGameState.PersistedData.MusicVolumeInDb;

        _soundlider = GetNode<HSlider>("Panel/VBoxContainer/SoundSlider");
        _soundlider.Value = GlobalGameState.PersistedData.SoundVolumeInDb;
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

    public void OnSoundSliderValueChanged(float value)
    {
        GlobalGameState.PersistedData.SoundVolumeInDb = (int)value;

        // Change actual music level
        this.GetGlobalAudioManager().UpdateAudioLevels(GlobalGameState.PersistedData);
    }
}
