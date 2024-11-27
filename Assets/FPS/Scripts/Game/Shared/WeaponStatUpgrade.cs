using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponStats
{
    [SerializeField]
    public float ammo;
    [SerializeField]
    public float fireRate;
    [SerializeField]
    public float shotCount;
    [SerializeField]
    public float rechargeSpeed;
    [SerializeField]
    public float damage;
    [SerializeField]
    public float chargeSpeed;
}
public class WeaponStatUpgrade : ScriptableObject
{
    public string weaponName;
    public WeaponStats stats;
}
