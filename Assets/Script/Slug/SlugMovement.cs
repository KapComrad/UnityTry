using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector3 _localScaleVector;

    [Header("Objects and Layers")]
    [SerializeField] private Transform _raycastCheckPoint;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private ParticleSystem _particleSystem;

    [Header("Float variables")]
    [SerializeField] private float _speed = -40f;
    [SerializeField] private float _wallCheckLength = 0.1f;
    [SerializeField] private float _groundCheckLength = 0.2f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    void Start()
    {
        _particleSystem.Play();
        _localScaleVector = transform.localScale;
    }

    void Update()
    {
        _rigidbody2D.velocity = new Vector2(_speed * Time.deltaTime, _rigidbody2D.velocity.y);
        if (IsWallOnRoad() || !IsRoadEnded())
        {
            _localScaleVector.x = -_localScaleVector.x;
            transform.localScale = _localScaleVector;
            _speed = -_speed;
            _wallCheckLength = -_wallCheckLength;
            _particleSystem.transform.Rotate(0, 180f, 0);
        }
        
    }

    private bool IsWallOnRoad()
    {
        return Physics2D.Raycast(_raycastCheckPoint.position,Vector2.left, _wallCheckLength,_groundLayer);
    }

    private bool IsRoadEnded()
    {
        return Physics2D.Raycast(_raycastCheckPoint.position, Vector2.down, _groundCheckLength, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_raycastCheckPoint.position, new Vector3(-_wallCheckLength,0,0));
        Gizmos.DrawRay(_raycastCheckPoint.position, new Vector3(0,-_groundCheckLength,0));
    }
}
