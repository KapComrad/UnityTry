using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerPickUp : MonoBehaviour
{
    private PlayerSounds _playerSounds;
    private void Awake()
    {
        _playerSounds = GetComponentInChildren<PlayerSounds>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            _playerSounds.PlaySound(1);
            collision.GetComponent<ICollectable>().PickUp();
        }
    }
}
