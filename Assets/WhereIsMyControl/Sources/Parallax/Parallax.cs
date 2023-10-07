using System;
using System.Collections;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _strength;
    [SerializeField] private bool _verticalParallax;

    private Vector3 _targetPreviousPosition;
    private Transform _target;

    public void Init(Transform target)
    {
        _target = target;
        _targetPreviousPosition = _target.position;

        StartCoroutine(ParallaxMover());
    }

    private IEnumerator ParallaxMover()
    {
        while (_target != null)
        {
            var delta = _target.position - _targetPreviousPosition;

            if (_verticalParallax == false)
                delta.y = 0;

            _targetPreviousPosition = _target.position;
            transform.position += delta * _strength;

            yield return null;
        }
    }
}
