using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private PlayerSounds _playerSounds;
        
        [Header("Movement")]
        [SerializeField] private float _speed = 1f;
        private int _jumpSoundInt = 0;

        [Header("Jump")]
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.2f, 0.2f);
        [SerializeField] private float _lastGroundedTime = 0f;
        [SerializeField] private float _jumpBufferTime = 0.2f;
        [SerializeField] private float _jumpTime = 0f;
        [SerializeField] private float _jumpMultiplier = 0f;
        [SerializeField] private float _fallMultiplier = 0f;
        [SerializeField] private float _jumpCounter = 0f;
        private Vector2 _vecGravity;
        public bool IsJumping { get; private set; }


        [Header("GameObjects")]
        [SerializeField] private Transform _groundCheckPoint;

        private Rigidbody2D _rigidbody2D;
        private LayerMask _groundLayer;

        private void Awake()
        {
            _playerSounds = GetComponentInChildren<PlayerSounds>();
        }
        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _vecGravity = new Vector2(0, -Physics2D.gravity.y);
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _groundLayer = LayerMask.GetMask("Ground");
        }

        void Update()
        {
            CheckJumpInput();
            GravityMultiplier();
            JumpMulpitlier();
        }
        private void FixedUpdate()
        {
            Movement();
            CheckIsOnGround();
        }
        private void CheckJumpInput()
        {   
            if (_playerInput.JumpInputDown)
            {
                Jump();
            }
            if (_playerInput.JumpInputUp)
            {
                JumpEnded();
            }
        }

        private void CheckIsOnGround()
        {
            _lastGroundedTime -= Time.deltaTime;
            if (IsGrounded())
            {
                _lastGroundedTime = _jumpBufferTime;
            }
        }
        public bool IsGrounded()
        {
            return Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer);
        }

        private void Movement()
        {
            _rigidbody2D.velocity = new Vector2(_speed * _playerInput.HorizontalInput, _rigidbody2D.velocity.y);
        }

        private void Jump()
        {
            if (_lastGroundedTime > 0 && IsGrounded())
            {
                _playerSounds.PlaySound(0);
                _lastGroundedTime = 0f;
                IsJumping = true;
                _jumpCounter = 0;
                _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }

        private void JumpEnded()
        {
            IsJumping = false;
            _jumpCounter = 0;

            if (_rigidbody2D.velocity.y > 0)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.6f);
            }
        }

        private void GravityMultiplier()
        {
            if (_rigidbody2D.velocity.y < 0.1f)
            {
                _rigidbody2D.velocity -= _vecGravity * _fallMultiplier * Time.deltaTime;
            }
        }

        private void JumpMulpitlier()
        {
            if (_rigidbody2D.velocity.y > 0 && IsJumping)
            {
                _jumpCounter += Time.deltaTime;
                if (_jumpCounter > _jumpTime) IsJumping = false;

                float t = _jumpCounter / _jumpTime;
                float currentJumpM = _jumpMultiplier;

                if (t > 0.5f)
                {
                    currentJumpM = _jumpMultiplier * (1 - t);
                }

                _rigidbody2D.velocity += _vecGravity * currentJumpM * Time.deltaTime;
            }
        }
    }


}
