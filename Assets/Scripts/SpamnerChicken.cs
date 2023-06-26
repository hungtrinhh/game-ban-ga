using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpamnerChicken : MonoBehaviour
{
    [Header("Prefaps")] [SerializeField] private Chicken ChickenPreFaps;
    [SerializeField] private GameObject PresenPreFaps;

    [Space] [SerializeField] private Transform ChickenPool;

    [SerializeField] private int CountPresen;

    [SerializeField] private GameObject BossPrefaps;
    private Vector3 SpawmPosition;

    private float GridSize = 1;

    [SerializeField] private int CountNumberChicken;


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
        CountPresen = Random.Range(1, 5);
        Debug.Log($"CountPresen : {CountPresen}");

        SpawmPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        SpawmPosition.x += ((GridSize / 2 + (width / 2 / 2)));
        SpawmPosition.y -= GridSize;
        SpawmPosition.z = 0;
        spawmGridChicken(Mathf.FloorToInt(height / 2 / GridSize), Mathf.FloorToInt(width / GridSize / 1.5f));
    }

    private void spawmGridChicken(int rowCount, int numberChicken)
    {
        float x = SpawmPosition.x;
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < numberChicken; j++)
            {
                SpawmPosition.x += GridSize;
                Chicken newChicken = Instantiate(ChickenPreFaps, SpawmPosition, Quaternion.identity);
                newChicken.transform.parent = ChickenPool;
                ++CountNumberChicken;

                if (CountPresen > 0 && Random.Range(0, 2) == 1)
                {
                    newChicken.PutPresent(PresenPreFaps);
                    --CountPresen;
                }
            }

            SpawmPosition.x = x;
            SpawmPosition.y -= GridSize;
        }
    }

    public void DecreNumberChicken()
    {
        if (--CountNumberChicken <= 10)
        {
            SummonBoss();
        }
    }

    private void SummonBoss()
    {
        BossPrefaps.SetActive(true);
    }
}