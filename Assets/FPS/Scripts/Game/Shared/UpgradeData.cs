using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Game
{
    public enum UpgradeType
    {
        WeaponUpgrade,
        PassiveUpgrade,
        WeaponUnlock,
        JetpackUnlock
    }
    [CreateAssetMenu]
    public class UpgradeData : ScriptableObject
    {
        [Header("Shared Parameters")]
        public UpgradeType upgradeType;
        public string upgradeName;
        public string description;
        // Start is called before the first frame update
        [Header ("Weapon Unlock Parameters")]
        public WeaponController weaponController;
        //public WeaponStatUpgrade weaponStat;

        [Header("Weapon Upgrade Parameters")]
        [SerializeField]
        public string weaponName;
        [SerializeField]
        public int ammo;
        [SerializeField]
        public float fireRate;
        [SerializeField]
        public int shotCount;
        [SerializeField]
        public float rechargeDelay;
        [SerializeField]
        public float chargeSpeed;

        [Header("Passive Upgrade Parameters")]
        public Item item;
    }
}
