using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class blinkText : MonoBehaviour
{
    // Start is called before the first frame update

    private Coroutine a;

    private void OnEnable()
    {
        a = StartCoroutine(BlingText(GetComponent<TMP_Text>()));
    }


    // Update is called once per frame
    void Update()
    {
    }


    private void OnDisable()
    {
        StopCoroutine(a);
    }


    IEnumerator BlingText(TMP_Text text)
    {
        int i = 0;
        while (i < 7)
        {
            text.enabled = false;
            yield return new WaitForSeconds(0.5f);
            text.enabled = true;
            yield return new WaitForSeconds(0.5f);
            i++;
        }

        SceneManager.LoadScene("StartScene");
    }
}