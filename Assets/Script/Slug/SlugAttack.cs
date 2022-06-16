using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = transform.position - collision.transform.position;
            direction.Normalize();
            collision.gameObject.GetComponent<PlayerTakeDamage>().TakeDamage(-direction);
        }

    }
}
