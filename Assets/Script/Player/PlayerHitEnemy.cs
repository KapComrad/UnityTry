using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerHitEnemy : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private Transform _enemyCheckPoint;
        [SerializeField] private float _bounceForce = 10;
        [SerializeField] private Vector2 _boxSize = new Vector2(1, -1);
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            if (Physics2D.OverlapBox(_enemyCheckPoint.position, Vector2.down, 0, _enemyLayer))
            {
                Physics2D.OverlapBox(_enemyCheckPoint.position, _boxSize , 0, _enemyLayer).GetComponent<IDamageble>().TakeDamage();
                _rigidbody2D.AddForce(Vector2.up * _bounceForce, ForceMode2D.Impulse);
            }
        }

    }


}
