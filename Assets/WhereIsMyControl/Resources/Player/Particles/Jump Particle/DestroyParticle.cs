using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    [SerializeField] private float _duration;

    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        
        if(_elapsedTime >= _duration)
        {
            Destroy(gameObject);
        }
    }
}
