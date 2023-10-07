using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueWindow _dialogue;
    [SerializeField] private List<string> _dialogues = new List<string>();
    [SerializeField] private List<Sprite> _sprites = new List<Sprite>();

    public event UnityAction DialogueEnded;
    
    private void OnEnable()
    {
        _dialogue.DialogueEnded += DisableWindow;
    }

    private void OnDisable()
    {
        _dialogue.DialogueEnded -= DisableWindow;
    }

    public void DisableWindow()
    {
        _dialogue.gameObject.SetActive(false);
        DialogueEnded?.Invoke();
    }

    public void EnableWindow()
    {
        _dialogue.gameObject.SetActive(true);
        _dialogue.SetSpritesAndStrokes(_dialogues, _sprites);
        _dialogue.ResetCounter();
        _dialogue.SetNextText();
    }
}
