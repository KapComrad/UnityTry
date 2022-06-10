using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class ItemPickUp : MonoBehaviour, ICollectable
{
    public void PickUp()
    {
        PlayerMovement.inputAction?.Invoke(1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PickUp();
        }
    }
}
