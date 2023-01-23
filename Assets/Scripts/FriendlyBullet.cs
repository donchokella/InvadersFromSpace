using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
    private float speed = 10f;

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Alien"))
        {
            //Destroy(gameObject);  
            other.gameObject.GetComponent<Alien>().Kill();
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            //Destroy(other.gameObject);
            //Destroy(gameObject);
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
