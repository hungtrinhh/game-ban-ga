using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpamnerChicken : MonoBehaviour
{
    [Header("Prefaps")] [SerializeField] private Chicken ChickenPreFaps;
    [SerializeField] private GameObject PresenPreFaps;

    [Space] [SerializeField] private Transform ChickenPool;

    [SerializeField] private int CountPresent;

    [FormerlySerializedAs("BossPrefaps")] [SerializeField] private GameObject BossPrefap;
    private Vector3 SpawmPosition;

    private float _gridSize = 1;

    [FormerlySerializedAs("CountNumberChicken")] [SerializeField] private int countNumberChicken;


    public static SpamnerChicken Instan;


    private void Awake()
    {
        Instan = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;

        /// get count of present to spawn present
        CountPresent = Random.Range(1, 5);
        Debug.Log($"CountPresen : {CountPresent}");

        
        
        SpawmPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        SpawmPosition.x += ((_gridSize / 2 + (width / 2 / 2)));
        SpawmPosition.y -= _gridSize;
        SpawmPosition.z = 0;
        spawmGridChicken(Mathf.FloorToInt(height / 2 / _gridSize), Mathf.FloorToInt(width / _gridSize / 1.5f));
    }

    /// spawn grid chicken in the scene
    private void spawmGridChicken(int rowCount, int numberChicken)
    {
        float x = SpawmPosition.x;
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < numberChicken; j++)
            {
                SpawmPosition.x += _gridSize;
                Chicken newChicken = Instantiate(ChickenPreFaps, SpawmPosition, Quaternion.identity);
                newChicken.transform.parent = ChickenPool;
                ++countNumberChicken;

                if (CountPresent > 0 && Random.Range(0, 2) == 1)
                {
                    newChicken.PutPresent(PresenPreFaps);
                    --CountPresent;
                }
            }

            SpawmPosition.x = x;
            SpawmPosition.y -= _gridSize;
        }
    }

    /// when chicken death funtion is called
    public void DecreNumberChicken()
    {
        if (--countNumberChicken <= 10)
        {
            SummonBoss();
        }
    }

    private void SummonBoss()
    {
        BossPrefap.SetActive(true);
    }
}