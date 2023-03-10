using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    public GameObject bulletPrefab;

    private Vector3 hMoveDist = new Vector3(0.05f, 0, 0);
    private Vector3 vMoveDist = new Vector3(0, 0.15f, 0);

    private const float MAX_LEFT = -3.4f;
    private const float MAX_RIGHT = 3.4f;

    public static List<GameObject> allAliens = new List<GameObject>();

    private bool movingRight;

    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;

    private const float MAX_MOVE_SPEED = 0.02f;


    private float shootTimer = 1f;
    private const float ShootTime = 1f;

    [SerializeField] private ObjectPool objectPool = null;


    public GameObject motherShipPrefab;
    private Vector3 motherShipSpawnPos = new Vector3(3, 7.8f, 0);
    private float motherShipTimer = 1f;
    private const float MOTHERSHIP_MIN = 15f;
    private const float MOTHERSHIP_MAX = 60f;

    private const float START_Y = 3.7f;
    private bool entering = true;

    void Start()
    {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Alien"))
        {
            allAliens.Add(gameObj);
        }
    }

    void Update()
    {
        if (entering)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 2);

            if (transform.position.y <= START_Y)
            {
                entering = false;
            }
        }
        else
        {
            if (moveTimer <= 0)
            {
                MoveEnemies();
            }

            if (shootTimer <= 0)
            {
                Shoot();
            }

            moveTimer -= Time.deltaTime;
            shootTimer -= Time.deltaTime;


            if (motherShipTimer <= 0)
            {
                SpawnMotherShip();
            }

            motherShipTimer -= Time.deltaTime;
        }
    }

    private void MoveEnemies()
    {
        int hitMax = 0;
        if (allAliens.Count > 0)
        {
            for (int i = 0; i < allAliens.Count; i++)
            {
                if (movingRight)
                {
                    allAliens[i].transform.position += hMoveDist;
                }
                else
                {
                    allAliens[i].transform.position -= hMoveDist;

                }

                if (allAliens[i].transform.position.x > MAX_RIGHT || allAliens[i].transform.position.x < MAX_LEFT)
                {
                    hitMax++;
                }

            }
            if (hitMax > 0)
            {
                for (int i = 0; i < allAliens.Count; i++)
                {
                    allAliens[i].transform.position -= vMoveDist;
                }
                movingRight = !movingRight;
            }
            moveTimer = GetMoveSpeed();
        }
    }

    private float GetMoveSpeed()
    {
        float f = allAliens.Count * moveTime;

        if (f < MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return f;
        }
    }

    private void Shoot()
    {
        Vector2 pos = allAliens[Random.Range(0, allAliens.Count)].transform.position;

        //Instantiate(bulletPrefab, pos, Quaternion.identity);
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = pos;

        //yield return new WaitForSeconds(cooldown);


        shootTimer = ShootTime;
    }

    private void SpawnMotherShip()
    {
        Instantiate(motherShipPrefab, motherShipSpawnPos, Quaternion.identity);
        motherShipTimer = Random.Range(MOTHERSHIP_MIN, MOTHERSHIP_MAX);
    }
}
