using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class CherryPickUp : MonoBehaviour, ICollectable
{
    public void PickUp()
    {
        PlayerStats.singleton.DoubleJump = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerSounds playerSounds = collision.GetComponentInChildren<PlayerSounds>();
            playerSounds.PlaySound(1);
            PickUp();
            Destroy(gameObject);
        }
    }

}
