using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;


public class Chicken : MonoBehaviour
{
    [Header("Prefaps")] [SerializeField] private GameObject ChickenLeg;
    [SerializeField] private GameObject Egg;
    private GameObject Present;

    [Space] [Header("Health of chicken")] [SerializeField]
    private float health = 5;
    private void Start()
    {
        StartCoroutine(SpawmEgg());
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            AudioController.Instan.PlayChickenDeath();
            Destroy(gameObject);
            return;
        }


        AudioController.Instan.PlayChickenHurt();
    }

    public void PutPresent(GameObject present)
    {
        this.Present = present;
    }


    IEnumerator SpawmEgg()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 30));
            Instantiate(Egg, transform.position, quaternion.identity);
        }
    }


    /// <summary>
    /// Set chicken color to green;
    /// </summary>
    public void SetColorToGreen()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
    }

    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        GameController.Instan.IncreamentScore(false);
        Instantiate(ChickenLeg, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 180))));
        if (this.Present != null)
        {
            Instantiate(Present, transform.position, quaternion.identity);
        }

        SpamnerChicken.Instan.DecreNumberChicken();
    }
}