using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _checkRadius;
    [SerializeField] private Transform _lowestPlayerPoint;
    [SerializeField] private LayerMask _groundLayer;

    public event UnityAction SpacePressed;

    private bool _isGrounded;

    private void Update()
    {
        TryTouchGround();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true){
            SpacePressed?.Invoke();
        }
    }

    private void TryTouchGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_lowestPlayerPoint.position, _checkRadius, _groundLayer);
    }
}
