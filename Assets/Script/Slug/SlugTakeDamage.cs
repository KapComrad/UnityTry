using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugTakeDamage : MonoBehaviour, IDamageble
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _hitAudio;
    [SerializeField] private SlugAnimation _slugAnimation;

    [SerializeField] private GameObject _particleSystem;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Behaviour[] _comps;

    private void Awake()
    {
        _audioSource = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioSource>();
    }
    private void Start()
    {
        _comps = GetComponentsInChildren<Behaviour>();
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
        foreach (var components in _comps)
        {
            if (!(components is Animator))
            components.enabled = false;
        }
        _particleSystem.SetActive(false);
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    public void DestroySlug()
    {
        Destroy(this.gameObject);
    }
}
