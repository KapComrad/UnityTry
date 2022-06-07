using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = -10f;
    [SerializeField] private Transform _wallCheckPoint;
    [SerializeField] private float _wallCheckLength = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private bool _isRightRotation;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(_speed * Time.deltaTime, _rigidbody2D.velocity.y);
        if (IsWallOnRoad() && !_isRightRotation)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _speed = -_speed;
            _isRightRotation = true;
        }
        else if (IsWallOnRoad() && _isRightRotation)
        {
            transform.localScale = new Vector3(1, 1, 1);
            _speed = -_speed;
            _isRightRotation = false;
        }
        
    }

    private bool IsWallOnRoad()
    {
        return Physics2D.Raycast(_wallCheckPoint.position,Vector2.left, _wallCheckLength,_groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_wallCheckPoint.position, Vector3.left);
    }
}
