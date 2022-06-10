using UnityEngine;
using System;

public class SlugAnimation : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SlugTakeDamage _slugTakeDamage;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
        _slugTakeDamage = GetComponentInParent<SlugTakeDamage>();
    }
    private void Update()
    {
        PlayMovementAnimation();
    }

    private void PlayMovementAnimation()
    {
        _animator.SetFloat("Velocity", Mathf.Abs(_rigidbody2D.velocity.x));
    }

    public void PlayHitAnimation()
    {
        _animator.SetTrigger("IsHurted");
    }
    public void AnimationDeathEnded()
    {
        _slugTakeDamage.DestroySlug();
    }
}
