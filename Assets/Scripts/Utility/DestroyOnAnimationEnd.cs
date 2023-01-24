using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimationEnd : MonoBehaviour
{
    public float delay; //maybe we can use

    private void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
