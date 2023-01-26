using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int scoreValue;
    public GameObject explosion;
    public GameObject coinPrefab;
    public GameObject lifePrefab;
    public GameObject healthPrefab;

    private const int LIFE_CHANCE = 1;
    private const int HEALTH_CHANCE = 10;
    private const int COIN_CHANCE = 50;

    public void Kill()
    {
        AlienMaster.allAliens.Remove(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);

        UIManager.UpdateScore(scoreValue);

        if (AlienMaster.allAliens.Count == 0)
        {
            GameManager.SpawnNewWave();
        }

        int rand = Random.Range(0, 500);

        if (rand <= LIFE_CHANCE)
        {
            Instantiate(lifePrefab, transform.position, Quaternion.identity);
        }
        else if (rand <= HEALTH_CHANCE)
        {
            Instantiate(healthPrefab, transform.position, Quaternion.identity);
        }
        else if (rand <= COIN_CHANCE)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    }
}
