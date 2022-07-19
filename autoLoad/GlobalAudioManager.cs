using Godot;

/// <summary>
/// 
/// See: https://docs.godotengine.org/en/stable/tutorials/audio/audio_streams.html
/// </summary>
public class GlobalAudioManager : Node
{
    // Folders to store child nodes
    Node _musicFolder;
    Node _soundsFolder;

    [Export]
    public PackedScene AudioMusicScene;

    // Currently playing music
    AudioMusic _currentMusic;

    public override void _Ready()
    {
        _musicFolder = GetNode<Node>("Music");
        _soundsFolder = GetNode<Node>("Sounds");
    }

    public void PlaySound(AudioStream audioStream)
    {
        var newSound = new AudioStreamPlayer
        {
            Stream = audioStream
        };

        // Add child
        _soundsFolder.AddChild(newSound);
        newSound.Connect("finished", this, nameof(OnSoundFinishedPlaying), new Godot.Collections.Array { newSound });
        newSound.Play();
    }

    public void PlayMusic(AudioStream audioStream)
    {
        if ( _currentMusic != null )
        {
            // Expire current music
            _currentMusic.FadeOutAndPlay();
        }

        _currentMusic = AudioMusicScene.Instance<AudioMusic>();
        _currentMusic.Connect(nameof(AudioMusic.OnFadeOut), this, nameof(OnAudioMusicFadeOutCallback));

        // Add child
        _musicFolder.AddChild(_currentMusic);

        // Start playing
        _currentMusic.FadeInAndPlay(audioStream);
    }

    public void OnAudioMusicFadeOutCallback(AudioMusicFadeOutMode fadeOutMode, AudioMusic instance)
    {
        // Remove expired music node only on fade out
        if (fadeOutMode == AudioMusicFadeOutMode.FadeOut)
        {
            _musicFolder.RemoveChild(instance);
            instance.QueueFree();
        }
    }

    public void OnSoundFinishedPlaying(AudioStreamPlayer player)
    {
        // sound finished playing, discard it
        _soundsFolder.RemoveChild(player);
        player.QueueFree();
    }
}

public static class GlobalAudioManagerExtensions
{
    // Retrieves an instance of a audio manager
    public static GlobalAudioManager GetGlobalAudioManager(this Node node)
    {
        return node.GetNode<GlobalAudioManager>($"/root/{nameof(GlobalAudioManager)}");
    }
}