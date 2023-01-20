using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float seconds = 2f;

    private void Start()
    {
        Destroy(gameObject, seconds);
    }
}
