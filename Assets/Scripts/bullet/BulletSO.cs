using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bullet", menuName = "SO/bullet", order = 1)]
public class BulletSO : ScriptableObject
{
    [SerializeField] private Sprite _bulletTexture;
    [SerializeField] private float _damage;
    [SerializeField] private int _tier;

    public Sprite BulletTexture => _bulletTexture;

    public float Damage
    {
        get => _damage;
    }

    public int Tier
    {
        get => _tier;
    }
}