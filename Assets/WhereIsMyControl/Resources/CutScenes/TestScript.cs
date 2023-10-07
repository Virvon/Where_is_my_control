using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TestScript : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;

    private void Start()
    {
        _director.Play();
    }
}
