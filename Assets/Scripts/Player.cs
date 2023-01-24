using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;

    private const float maxX = 2.18f;
    private const float minX = -2.18f;

    //private float speed = 3f;
    private bool isShooting;    // false by default
    //private float cooldown = 0.5f;
    [SerializeField] private ObjectPool objectPool = null;


    public ShipStats shipStats;
    private Vector2 offScreenPos = new Vector2(0, -20);
    private Vector2 startPos = new Vector2(0, -4f);

    private void Start()
    {
        shipStats.currentHealth = shipStats.maxHealth;
        shipStats.currentLife = shipStats.maxLifes;
        transform.position = startPos;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A) && transform.position.x > minX)
        {
            transform.Translate(Vector2.left * Time.deltaTime * shipStats.shipSpeed);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
        {
            transform.Translate(Vector2.right * Time.deltaTime * shipStats.shipSpeed);
        }
        if (Input.GetKey(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(Shoot());
        }
#endif
    }

    private IEnumerator Shoot()
    {
        isShooting = true;

        //Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = gameObject.transform.position;

        yield return new WaitForSeconds(shipStats.fireRate);

        isShooting = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            other.gameObject.SetActive(false);
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        shipStats.currentHealth--;

        if (shipStats.currentHealth <= 0)
        {
            shipStats.currentLife--;
            if (shipStats.currentLife <= 0)
            {
                Debug.Log("gameover");
            }
            else
            {
                //Debug.Log("respawn");
                StartCoroutine(Respawn());
            }
        }
    }

    public IEnumerator Respawn()
    {
        transform.position = offScreenPos;

        yield return new WaitForSeconds(2);

        shipStats.currentHealth = shipStats.maxHealth;

        transform.position = startPos;
    }
}
