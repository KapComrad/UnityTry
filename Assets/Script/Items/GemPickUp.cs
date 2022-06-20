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
