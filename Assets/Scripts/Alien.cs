using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int scoreValue;
    public GameObject explosion;

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
    }
}
