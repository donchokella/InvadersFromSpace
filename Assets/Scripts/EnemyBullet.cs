using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

    }
}