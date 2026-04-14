using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioToggler : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";
    private const float MutedVolume = -80f;
    private const float FullVolume = 0f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Button _muteButton;

    private bool _isMuted = false;

    private void OnEnable()
    {
        _muteButton.onClick.AddListener(Toggle);
    }

    private void OnDisable()
    {
        _muteButton.onClick.RemoveListener(Toggle);
    }

    private void Toggle()
    {
        _isMuted = _isMuted == false;
        _audioMixer.SetFloat(MasterVolume, _isMuted ? MutedVolume : FullVolume);
    }
}