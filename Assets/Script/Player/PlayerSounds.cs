using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerSounds : MonoBehaviour
    {
        private PlayerInput _playerInput;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _audioClips;

        private void OnEnable()
        {
            PlayerMovement.inputAction += PlaySound;
        }

        private void OnDisable()
        {
            PlayerMovement.inputAction -= PlaySound;
        }

        private void PlaySound(int soundNumber)
        {
            _audioSource.clip = _audioClips[soundNumber];
            _audioSource.Play();

        }
    }

}

