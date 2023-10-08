using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsMixer : MonoBehaviour
{
    [SerializeField] private PlayerDeath _death;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private float _soundVolume;

    private void Start()
    {
        _deathSound.volume = _soundVolume;
        _jumpSound.volume = _soundVolume;
    }

    private void OnEnable()
    {
        _death.Died += MakeDeathSound;
        _movement.Jumped += MakeJumpSound;
    }

    private void OnDisable()
    {
        _death.Died -= MakeDeathSound;
        _movement.Jumped -= MakeJumpSound;
    }

    private void MakeJumpSound()
    {
        _jumpSound.Play();
    }

    private void MakeDeathSound()
    {
        _jumpSound.Play();
    }
}
