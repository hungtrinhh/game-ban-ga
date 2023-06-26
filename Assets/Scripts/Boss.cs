using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    [Header("Prefap")] [SerializeField] private GameObject Egg;

    [Space] [Header("Health Boss")] [SerializeField]
    private float _heath = 100;

    [Space] [SerializeField] private GameObject DestroyVFX;
    [SerializeField] private TMP_Text StatusText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveBossToRandomPositon());
        StartCoroutine(SpawmEgg());
    }

    IEnumerator MoveBossToRandomPositon()
    {
        Debug.Log(1);
        Vector3 direction = RandowPosition() - transform.position;
        Vector3 pos = transform.position + direction.normalized;
        while (transform.position != pos)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, 0.01f);

            yield return null;
        }

        Debug.Log(2);
        StartCoroutine(MoveBossToRandomPositon());
    }

    IEnumerator SpawmEgg()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
            Instantiate(Egg, transform.position + Vector3.down, Quaternion.identity);
        }
    }


    public void GetDame(float damage)
    {
        _heath = (_heath - damage);
        if (_heath <= 0)
        {
            Destroy(gameObject);
        }
    }

    Vector3 RandowPosition()
    {
        Vector3 Position = new Vector3();
        Position.y = Random.Range
        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y,
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.height / 2, Screen.height)).y);
        Position.x = Random.Range
        (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x,
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        return Position;
    }

    public void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
            return;

        GameController.Instan.IncreamentScore(1000);
        Destroy(Instantiate(DestroyVFX, transform.position, Quaternion.identity), 1f);

        StatusText.text = "Win!!!!";
        StatusText.color = Color.green;
        StatusText.gameObject.SetActive(true);
    }
}