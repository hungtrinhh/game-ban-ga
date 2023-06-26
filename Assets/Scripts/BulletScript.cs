using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private BulletSO TierBullet;


    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
    }

    private void OnEnable()
    {
        if (TierBullet != null)
        {
            TierBullet = ShipController.Instan.CurentTier;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = TierBullet.BulletTexture;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TierBullet = ShipController.Instan.CurentTier;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = TierBullet.BulletTexture;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * (Time.deltaTime * speed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ship") || other.CompareTag("Chicken leg") || other.CompareTag("Egg"))
        {
            return;
        }

        //dispawm viên đạn trở về pool


        if (other.CompareTag("Chicken"))
        {
            Chicken chicken = other.GetComponent<Chicken>();
            chicken.GetDamage(TierBullet.Damage);
        }
        else if (other.CompareTag("ChickenBoss"))
        {
            Boss boss = other.GetComponent<Boss>();
            boss.GetDame(TierBullet.Damage);
        }
        ShipController.Instan.DisSpawmBullet(this.gameObject);
    }
}