using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private float _duration;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _startValue;
 
    private const int MaxMixerValue = 0;
    private const int MinMixerValue = -80;
    private float _currentValue;

    private void OnEnable()
    {
        _slider.value = _currentValue;
        _slider.onValueChanged.AddListener(ChangeVolume);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(ExitGame);
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void Awake()
    {
        _currentValue = _startValue;
        float value = -(MaxMixerValue - MinMixerValue) * _startValue;
        _mixer.audioMixer.SetFloat("MasterVolume", value);
    }

    public void ChangeVolume(float value)
    {
        _currentValue = value;
        _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(MinMixerValue, MaxMixerValue, value));
    }

    private void ExitGame()
    {
        Application.Quit();
    }

}
