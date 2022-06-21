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
