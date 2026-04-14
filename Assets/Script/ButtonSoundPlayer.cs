using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private Button[] _buttons;

    private void OnEnable()
    {
        foreach (var button in _buttons)
        {
            button.onClick.AddListener(Play);
        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
        {
            button.onClick.RemoveListener(Play);
        }
    }

    private void Play()
    {
        _source.PlayOneShot(_clip);
    }
}