using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesTransitions : MonoBehaviour
{
    [SerializeField] private List<DialogueManager> _dialogues = new List<DialogueManager>();

    private int _counter = -1;

    private void OnEnable()
    {
        foreach (DialogueManager manager in _dialogues)
        {
            manager.gameObject.SetActive(false);
        }

        foreach (DialogueManager manager in _dialogues)
        {
            manager.DialogueEnded += SetNextDialogue;
        }
    }

    private void OnDisable()
    {
        foreach (DialogueManager manager in _dialogues)
        {
            manager.DialogueEnded -= SetNextDialogue;
        }
    }

    private void Start()
    {
        SetNextDialogue();
    }

    private void SetNextDialogue()
    {
        if (_counter >= _dialogues.Count - 1)
        {
            return;
        }
        _counter++;

        if(_counter != 0)
        {
            int previousDialogue = _counter - 1;
            _dialogues[previousDialogue].gameObject.SetActive(false);
        }

        _dialogues[_counter].gameObject.SetActive(true);
    }
}
