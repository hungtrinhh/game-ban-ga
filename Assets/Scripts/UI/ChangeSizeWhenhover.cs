using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSizeWhenhover : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onClick;


    public void OnPointerClick(PointerEventData eventData)
    {
        GotoSceneGame();
    }

    public void GotoSceneGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}