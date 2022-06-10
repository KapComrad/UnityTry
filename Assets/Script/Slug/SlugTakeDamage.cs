using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugTakeDamage : MonoBehaviour, IDamageble
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _hitAudio;
    [SerializeField] private SlugAnimation _slugAnimation;

    [SerializeField] private GameObject _particleSystem;
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SlugMovement _slugMovement;

    private void Awake()
    {
        _audioSource = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioSource>();
    }

    public void TakeDamage()
    {
        _audioSource.clip = _hitAudio;
        _audioSource.PlayOneShot(_hitAudio);
        _slugAnimation.PlayHitAnimation();
        DisableComponents();
    }

    private void DisableComponents()
    {
        _particleSystem.SetActive(false);
        _boxCollider.enabled = false;
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        _slugMovement.enabled = false;
    }

    public void DestroySlug()
    {
        Destroy(this.gameObject);
    }
}
