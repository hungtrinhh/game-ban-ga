using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;


    private void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
        StartCoroutine(CheckPosition());
    }

    IEnumerator CheckPosition()
    {
        while (true)
        {
            Vector3 a = Camera.main.WorldToViewportPoint(transform.position);

            if (a.y < 0.1f)
            {
                _rigidbody2D.bodyType = RigidbodyType2D.Static;

                _animator.SetTrigger("break");

                Destroy(gameObject, 1.5f);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}