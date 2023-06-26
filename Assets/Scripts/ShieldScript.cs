using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    [SerializeField] private float Speed = 50;

    private void Start()
    {
        StartCoroutine(Rotate());
    }

  


    IEnumerator Rotate()
    {
        while (gameObject.activeSelf)
        {
            transform.Rotate(new Vector3(0, 0, 5) * (Time.deltaTime * Speed));
            yield return null;
        }
    }
    
}