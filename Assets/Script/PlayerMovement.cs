using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 1f;
    
    [Header("Jump")]
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private bool _isJumping = false;
    [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.2f, 0.2f);
    [SerializeField] private float _lastGroundedTime = 0f;
    [SerializeField] private float _jumpBufferTime = 0.2f;
    [SerializeField] private float _jumpTime = 0f;
    [SerializeField] private float _jumpMultiplier = 0f;
    [SerializeField] private float _fallMultiplier = 0f;
    [SerializeField] private float _jumpCounter = 0f;
    private Vector2 _vecGravity;


    [Header("GameObjects")]
    [SerializeField] private Transform _groundCheckPoint;
    private Rigidbody2D _rigidBody2D;

    private LayerMask _groundLayer;
    private float _InputHorizontal;

    private void Start()
    {
        _vecGravity = new Vector2(0, -Physics2D.gravity.y);
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _groundLayer = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        CheckInput();
        GravityMultiplier();
        JumpMulpitlier();
    }
    private void FixedUpdate()
    {
        Movement();
        CheckIsOnGround();
    }
    private void CheckInput()
    {
        _lastGroundedTime -= Time.deltaTime;
        _InputHorizontal = Input.GetAxis("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
        { 
            Jump();
        }
        if (Input.GetButtonUp("Jump"))
        {
            _isJumping = false;
            _jumpCounter = 0;

            if (_rigidBody2D.velocity.y > 0 )
            {
                _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, _rigidBody2D.velocity.y * 0.6f);
            }
        }
    }

    private void CheckIsOnGround()
    {
        if (IsGrounded())
        {
            _lastGroundedTime = _jumpBufferTime;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer);
    }

    private void Movement()
    {
        _rigidBody2D.velocity = new Vector2(_speed * _InputHorizontal, _rigidBody2D.velocity.y);
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_groundCheckPoint.position, _groundCheckSize);
    }
    */

    private void Jump()
    {
        if (_lastGroundedTime > 0 && IsGrounded())
        {
            _lastGroundedTime = 0f;
            _isJumping = true;
            _jumpCounter = 0;
            _rigidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void GravityMultiplier()
    {
        if (_rigidBody2D.velocity.y < 0.1f)
        {
            _rigidBody2D.velocity -= _vecGravity * _fallMultiplier * Time.deltaTime;
        }
    }

    private void JumpMulpitlier()
    {
        if (_rigidBody2D.velocity.y > 0 && _isJumping)
        {
            _jumpCounter += Time.deltaTime;
            if (_jumpCounter > _jumpTime) _isJumping = false;

            float t = _jumpCounter / _jumpTime;
            float currentJumpM = _jumpMultiplier;

            if (t > 0.5f)
            {
                currentJumpM = _jumpMultiplier * (1 - t);
            }

            _rigidBody2D.velocity += _vecGravity * currentJumpM * Time.deltaTime;
        }
    }
}
