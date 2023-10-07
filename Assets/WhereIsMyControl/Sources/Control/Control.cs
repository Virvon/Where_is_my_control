using System;
using System.Collections;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private float _spawnOffset;
    [SerializeField] private float _spawnMoveSpeed;
    [SerializeField] private float _verticalPosition;
    [SerializeField] private float _offset;
    [SerializeField] private float _followSpeed;

    private Transform _target;
    private PlayerDeath _playerDeath;
    private Coroutine _currentCoroutine;

    private void OnDisable()
    {
        _playerDeath.Died -= OnDied;
    }

    public void Init(PlayerDeath playerDeath)
    {
        _target = playerDeath.transform;
        _playerDeath = playerDeath;

        transform.position = new Vector2(_target.position.x + _spawnOffset, _verticalPosition);

        _playerDeath.Died += OnDied;

        _currentCoroutine = StartCoroutine(SpawnMover());
    }

    private void OnDied()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        StartCoroutine(Destroyer());
    }

    private IEnumerator SpawnMover()
    {
        Vector2 targetPosition = new Vector2(_offset, _verticalPosition);
        float time = 0;

        while(transform.position != new Vector3(targetPosition.x + _target.position.x, targetPosition.y, transform.position.z))
        {
            time += Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x + _target.position.x, targetPosition.y, transform.position.z), time / _spawnMoveSpeed);

            yield return null;
        }

        _currentCoroutine = StartCoroutine(Follower());
    }

    private IEnumerator Follower()
    {
        while(_target != null)
        {
            Vector2 targetPosition = new Vector2(_target.position.x + _offset, _target.position.y);
            Vector2 verticalPosition = Vector2.MoveTowards(transform.position, targetPosition, _followSpeed * Time.deltaTime);

            transform.position = new Vector2(targetPosition.x, verticalPosition.y);


            yield return null;
        }
    }

    private IEnumerator Destroyer()
    {
        Vector3 targetPosition = new Vector3(transform.position.x + _spawnOffset, transform.position.y, transform.position.z);
        float time = 0;

        while(transform.position != targetPosition)
        {
            time += Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, targetPosition, time / _spawnMoveSpeed);

            yield return null;
        }

        Destroy(gameObject);
    }
}