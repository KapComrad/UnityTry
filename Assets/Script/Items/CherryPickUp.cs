using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class CherryPickUp : MonoBehaviour, ICollectable
{
    public void PickUp()
    {
        PlayerStats.singleton.NumberOfJumps++;
        Destroy(gameObject);
    }
}
