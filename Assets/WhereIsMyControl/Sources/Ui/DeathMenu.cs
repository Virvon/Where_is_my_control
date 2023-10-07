using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DeathMenu : MonoBehaviour
{
    private Animator _animator;
    private event Action Callback;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open(Action callback = null)
    {
        Callback = callback;

        _animator.SetTrigger(Animation.DeathMenuAnimation.Open);
    }

    public void OnOpened() => 
        Callback?.Invoke();
    
    public void Close(Action callback = null)
    {
        Callback = callback;

        _animator.SetTrigger(Animation.DeathMenuAnimation.Close);
    }

    public void OnClosed() =>
        Callback?.Invoke();
}