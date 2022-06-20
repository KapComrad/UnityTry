using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class ItemPickUp : MonoBehaviour, ICollectable
{
    public void PickUp()
    {
        Destroy(gameObject);
    }

}
