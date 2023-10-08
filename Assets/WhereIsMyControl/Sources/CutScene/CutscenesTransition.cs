using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutscenesTransition : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogue;
    [SerializeField] private PlayableDirector _director;

    private void OnEnable()
    {
        _dialogue.DialogueEnded += StartNextCutScene;
    }

    private void OnDisable()
    {
        _dialogue.DialogueEnded -= StartNextCutScene;
    }

    private void StartNextCutScene()
    {
        _director.gameObject.SetActive(true);
        _director.Play();
    }
}
