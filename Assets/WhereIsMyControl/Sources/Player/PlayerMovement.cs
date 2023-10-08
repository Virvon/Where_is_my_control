using System;
using System.Collections.Generic;
using UnityEngine;
using WhereIsMyControl.Services;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _stopSpeed;

    public float MinGroundNormalY = .65f;
    public float GravityModifier = 1f;
    public Vector2 Velocity;
    public LayerMask LayerMask;

    private IInputService _input;
    private bool _canJump;

    protected Vector2 targetVelocity;
    protected bool grounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2d;
    protected ContactFilter2D contactFilter;

    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    public event Action Jumped;

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(LayerMask);
        contactFilter.useLayerMask = true;
    }

    private void OnDestroy()
    {
        _input.Jumped -= OnJumped;
    }

    private void FixedUpdate()
    {
        Velocity += GravityModifier * Physics2D.gravity * Time.deltaTime;
        Velocity.x = targetVelocity.x;

        grounded = false;

        Vector2 deltaPosition = Velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    public void Init(IInputService input)
    {
        _input = input;
        _canJump = true;

        targetVelocity = new Vector2(_speed, 0);

        _input.Jumped += OnJumped;
    }

    public void Stop()
    {
        _canJump = false;
        targetVelocity = Vector2.zero;
    }

    private void OnJumped()
    {
        if (grounded && _canJump)
        {
            Velocity.y = _jumpForce;
        }
    }

    private void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);

            hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > MinGroundNormalY)
                {
                    grounded = true;

                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(Velocity, currentNormal);
                if (projection < 0)
                {
                    Velocity = Velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        rb2d.position = rb2d.position + move.normalized * distance;
    }
}
