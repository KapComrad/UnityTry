using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class CherryPickUp : MonoBehaviour, ICollectable
{
    public void PickUp()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.inputAction?.Invoke(1);
            Destroy(gameObject);
        }
    }
}
