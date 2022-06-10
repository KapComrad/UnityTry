using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerSounds : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _audioClips;

        public void PlaySound(int soundNumber)
        {
            _audioSource.PlayOneShot(_audioClips[soundNumber]);
        }
    }

}

