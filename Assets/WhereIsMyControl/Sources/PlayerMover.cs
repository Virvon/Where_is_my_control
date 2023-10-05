using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;   
    [SerializeField] private PlayerInput _input;

    private Rigidbody2D _rigidBody2D;

    private void OnEnable()
    {
        _input.SpacePressed += Jump;   
    }

    private void OnDisable()
    {
        _input.SpacePressed -= Jump;
    }

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidBody2D.velocity = new Vector2(_speed, _rigidBody2D.velocity.y);
    }

    private void Jump()
    {
        _rigidBody2D.AddForce(Vector2.up * _jumpForce);
    }
}
