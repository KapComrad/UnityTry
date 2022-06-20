using System;
using UnityEngine;
using Player;

public class GemPickUp : MonoBehaviour, ICollectable
{
    public static Action AddScoreEvent;

    public void PickUp()
    {
        PlayerStats.singleton.ScoreIncrease();
        AddScoreEvent?.Invoke();
        Destroy(gameObject);
    }

}
