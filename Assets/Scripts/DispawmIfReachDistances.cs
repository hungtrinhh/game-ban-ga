using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispawmIfReachDistances : MonoBehaviour
{
    [SerializeField] private float Distances = 80f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0))) >=
            Distances)
        {
            ShipController.Instan.DisSpawmBullet(gameObject);
        }
    }
}