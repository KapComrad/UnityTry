using UnityEngine;
using System;
using System.Collections;
using Player;

public class PlayerTakeDamage : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private PlayerMovement _playerMovement;
    private PlayerAnimation _playerAnimation;

    [SerializeField] private float _pushPower = 5;
    [SerializeField] private float _invincibleTime = 2f;
    [SerializeField] private float _loseControlTime = 0.5f;
    private bool _isInvincible = false;

    public static Action PlayerTakeDamageEvent;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
    }
    public void TakeDamage(Vector2 direction)
    {
        if (!_isInvincible)
        {
            _playerMovement.IsTakingDamage = true;
            _isInvincible = true;
            _rigidbody2D.AddForce(direction * _pushPower, ForceMode2D.Impulse);

            StartCoroutine(PushTime());
            StartCoroutine(InvincibleTime());
            PlayerStats.singleton.HealthDecrease();
            PlayerTakeDamageEvent?.Invoke();
        }
    }

    IEnumerator PushTime()
    {
        _playerAnimation.TakeDamageAnimationPlay(_invincibleTime);
        yield return new WaitForSeconds(_loseControlTime);
        _playerMovement.IsTakingDamage = false;
    }

    IEnumerator InvincibleTime()
    {
        yield return new WaitForSeconds(_invincibleTime);
        _isInvincible = false;
    }
}
