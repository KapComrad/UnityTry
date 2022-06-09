using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugTakeDamage : MonoBehaviour, IDamageble
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _hitAudio;

    public void TakeDamage()
    {
        _audioSource.clip = _hitAudio;
        _audioSource.Play();
        Destroy(gameObject);
    }
}
