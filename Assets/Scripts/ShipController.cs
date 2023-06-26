using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public static ShipController Instan;

    [SerializeField] private BulletSO[] ListBulletSO;

    [SerializeField] private int currentTier;

    [SerializeField] private List<GameObject> ListPoolBullet;

    [SerializeField] private GameObject PrefapsBullet;

    [SerializeField] private Ship PreFapsShip;


    private Ship ShipCurrent;

    public bool isProcess { get; private set; }


    // 2 game object chứa đạn được bắn và đạn nạp về  (holder chứa đạn dã được nạo về ,pool chứa đạn được bắn ra )
    [SerializeField] private Transform PoolBullet;
    [SerializeField] private Transform Holder;

    private void Awake()
    {
        if (Instan == null)
        {
            Instan = this;
        }

        ListPoolBullet = new List<GameObject>();
    }

    private void Start()
    {
        SpawmShipIfDestroy();
    }

    public void SpawmShipIfDestroy()
    {
        isProcess = false;
        ShipCurrent = Instantiate(PreFapsShip, new Vector3(0, -20, 0), new());
        StartCoroutine(MoveShipToPoin());
    }


    private float Timer;

    IEnumerator MoveShipToPoin()
    {
        Vector3 TopPoin = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 4, 0));
        TopPoin.z = 0;
        while (TopPoin != ShipCurrent.transform.position)
        {
            Timer += Time.deltaTime / 2;
            ShipCurrent.transform.position = Vector3.Lerp(ShipCurrent.transform.position, TopPoin, Timer);

            yield return null;
        }

        Timer = 0;
        isProcess = true;
    }

    public BulletSO CurentTier => ListBulletSO[currentTier];


    public void GetBulletfromPool(Vector3 positionSpawm)
    {
        if (ListPoolBullet.Count > 0)
        {
            GameObject bullet = ListPoolBullet[0];
            bullet.transform.position = positionSpawm;
            bullet.SetActive(true);
            ListPoolBullet.Remove(bullet);
            bullet.transform.parent = PoolBullet;
            return;
        }

        Instantiate(PrefapsBullet, positionSpawm, new()).transform.parent = PoolBullet;
    }

    public void IncreaTierBullet()
    {
        AudioController.Instan.PlayLevelUpSound();
        if (++currentTier >= ListBulletSO.Length)
        {
            currentTier = ListBulletSO.Length - 1;
        }
    }

    public void DisSpawmBullet(GameObject bullet)
    {
        bullet.transform.parent = Holder;
        bullet.SetActive(false);
        ListPoolBullet.Add(bullet);
    }
}