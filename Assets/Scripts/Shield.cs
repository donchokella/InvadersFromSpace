using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Sprite[] states;
    private int health;
    private SpriteRenderer sr;

    private void Start()
    {
        health = 4;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("FriendlyBullet"))
        {
            other.gameObject.SetActive(false);
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                sr.sprite = states[health - 1];
            }
        }
    }
}
