using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float seconds = 3f;

    private void Start()
    {
        Destroy(gameObject, seconds);
    }
}
