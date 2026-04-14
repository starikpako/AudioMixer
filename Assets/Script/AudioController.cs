using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";
    private const string MusicVolume = "MusicVolume";
    private const string EffectsVolume = "EffectsVolume";
    private const float VolumeMultiplier = 20f;
    private const float MinSliderValue = 0.0001f;
    private const float MutedVolume = -80f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectsSource;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private AudioClip[] _buttonClips;

    private bool _isMuted = false;

    private void Awake()
    {
        _masterSlider.onValueChanged.AddListener(SetMasterVolume);
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
    }

    private void Start()
    {
        SetMasterVolume(_masterSlider.value);
        SetMusicVolume(_musicSlider.value);
        SetEffectsVolume(_effectsSlider.value);
    }

    public void SetMasterVolume(float value)
    {
        if (_isMuted == false)
        {
            _audioMixer.SetFloat(MasterVolume, CalculateDb(value));
        }
    }

    public void SetMusicVolume(float value)
    {
        _audioMixer.SetFloat(MusicVolume, CalculateDb(value));
    }

    public void SetEffectsVolume(float value)
    {
        _audioMixer.SetFloat(EffectsVolume, CalculateDb(value));
    }

    public void PlaySound(int index)
    {
        _effectsSource.PlayOneShot(_buttonClips[index]);
    }

    public void ToggleMute()
    {
        _isMuted = _isMuted == false;

        if (_isMuted)
        {
            _audioMixer.SetFloat(MasterVolume, MutedVolume);
        }
        else
        {
            SetMasterVolume(_masterSlider.value);
        }
    }

    private float CalculateDb(float value)
    {
        return Mathf.Log10(Mathf.Max(value, MinSliderValue)) * VolumeMultiplier;
    }
}