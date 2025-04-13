using System;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform cameraTransform;
    private Animator anim;
    private Collider2D coll;
    public LayerMask ground;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _health = 100;
    private readonly float jumpForce = 10f;

    public enum State { idle, walking, jumping, falling}

    private State state = State.idle;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        cameraTransform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        PlayerEvents.OnPlayerMovement += Move;
        PlayerEvents.OnPlayerStop += StopMovement;
        PlayerEvents.OnPlayerJump += Jump;
    }

    private void OnDisable()
    {
        PlayerEvents.OnPlayerMovement -= Move;
        PlayerEvents.OnPlayerStop -= StopMovement;
        PlayerEvents.OnPlayerJump -= Jump;
        
    }
    private void Update()
    {
        HandleStateChanges();
        anim.SetInteger("state", (int)state);
    }

    private void Move(Vector2 direction)
    {
        _rb.linearVelocity = new Vector2(direction.x * _moveSpeed, _rb.linearVelocity.y);
        UpdateFacingDirection(direction.x);
    }

    private void UpdateFacingDirection(float facingDirection)
    {
        Vector3 cameraRight = cameraTransform.right;
        cameraRight.z = 0;
        cameraRight.Normalize();
        float dotProduct = Vector3.Dot(cameraRight, new Vector3(facingDirection, 0, 0));
        transform.localScale = new Vector2(Mathf.Sign(dotProduct), 1);
    }
    private void StopMovement()
    {
        _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);

    }
    private void Jump()
    {

        if (coll.IsTouchingLayers(ground))
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
            state = State.jumping;
        }
    }
    private void HandleStateChanges()
    {
        if (state == State.jumping)
        {
            if (_rb.linearVelocity.y < .1f)
                state = State.falling;

        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
                state = State.idle;
        }

        else if (Mathf.Abs(_rb.linearVelocity.x) > Mathf.Epsilon)
        {
            state = State.walking;

        }
        else
        {
            state = State.idle;
        }
    }
}
