using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeHandler : MonoBehaviour
{
    private const float VolumeMultiplier = 20f;
    private const float MinSliderValue = 0.0001f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _parameterName;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    private void Start()
    {
        SetVolume(_slider.value);
    }

    private void SetVolume(float value)
    {
        float dbVolume = Mathf.Log10(Mathf.Max(value, MinSliderValue)) * VolumeMultiplier;
        _audioMixer.SetFloat(_parameterName, dbVolume);
    }
}