using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Object = System.Object;

public class Ship : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] private float Speed;

    [SerializeField] private Transform TransformShield;

    [SerializeField] private float TimeProtect = 5;

    [Header("VFX")] [SerializeField] private GameObject ExplosionVFX;
    private Camera _camera;

    private bool isProtect = true;


    private void Start()
    {
        _camera = Camera.main;
        Invoke("DisableShield", TimeProtect);
    }


    public void DisableShield()
    {
        TransformShield.gameObject.SetActive(false);
        isProtect = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!ShipController.Instan.isProcess)
        {
            return;
        }

        MoveShip();
        if (Input.GetMouseButtonDown(0))
        {
            Shotting();
        }
    }

    void Shotting()
    {
        AudioController.Instan.PlayFireSound();

        ShipController.Instan.GetBulletfromPool(transform.position);
    }


    void MoveShip()
    {
        this._camera.WorldToScreenPoint(this.transform.position);
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if ((double)x != 0.0 && (double)y != 0.0)
        {
            x /= 2f;
            y /= 2f;
        }

        Vector3 TopleffPoint =
            this._camera.ScreenToWorldPoint(new Vector3((float)Screen.width, (float)Screen.height, 0.0f));
        this.transform.Translate(Vector3.right * (x * Time.deltaTime * this.Speed));
        this.transform.Translate(Vector3.up * (y * Time.deltaTime * this.Speed));
        this.transform.position =
            new Vector3(Mathf.Clamp(this.transform.position.x, TopleffPoint.x * -1f, TopleffPoint.x),
                Mathf.Clamp(this.transform.position.y, TopleffPoint.y * -1f, TopleffPoint.y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // tăng điểm;
        if (other.CompareTag("Chicken leg"))
        {
            AudioController.Instan.PlayPlayreEat();
            GameController.Instan.IncreamentScore(true);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Present"))
        {
            Debug.Log("aaaaaaaaaaaaaaaaaa");
            ShipController.Instan.IncreaTierBullet();
            Destroy(other.gameObject);
        }
        else if (!isProtect)
        {
            if (other.CompareTag("Chicken") || other.CompareTag("Egg"))
            {
                Destroy(gameObject);
                AudioController.Instan.PlaySoundPlayerDeath();
            }
        }
        // tăng tier đạn
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        OnTriggerEnter2D(other);
    }


    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded || (Object)ShipController.Instan == (Object)null)
            return;
        ShipController.Instan.SpawmShipIfDestroy();

        Destroy(Instantiate(ExplosionVFX, transform.position, Quaternion.identity), 1f);
    }
}