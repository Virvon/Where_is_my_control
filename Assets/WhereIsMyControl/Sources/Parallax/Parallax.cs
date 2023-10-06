using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField, Range(0, 1)] private float _strength;
    [SerializeField] private bool _verticalParallax;

    private Vector3 _targetPreviousPosition;

    private void Start()
    {
        if (_target == null)
            _target = Camera.main.transform;

        _targetPreviousPosition = _target.position;
    }

    private void Update()
    {
        var delta = _target.position - _targetPreviousPosition;

        if (_verticalParallax == false)
            delta.y = 0;

        _targetPreviousPosition = _target.position;
        transform.position += delta * _strength;
    }
}
