using System;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

public class PlayerWeaponUpgradeManager : MonoBehaviour
{
    public PlayerWeaponsManager playerWeaponsManager;
    public Experience experience;

    [SerializeField]
    public List<WeaponController> weapons;

    public GameObject gunParent;

    // Start is called before the first frame update
    void Start()
    {

        playerWeaponsManager= GetComponent<PlayerWeaponsManager>();
        experience= GetComponent<Experience>();
    }

    // Update is called once per frame
    public void AddWeapon(WeaponController weapon)
    {
        if(weapons ==  null)
        {
            weapons= new List<WeaponController>();
        }
        weapons.Add(weapon);
        if(experience==null)
        {
            experience = GetComponent<Experience>();
        }
        experience.upgrades.AddRange(weapon.upgrades);
        playerWeaponsManager.AddWeapon(weapon);
    }

    public void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponController weaponToUpgrade = null;
        for(int i = 0;i<gunParent.transform.childCount;i++)
        {
            var currentWeapon = gunParent.transform.GetChild(i).GetComponent<WeaponController>();
            if(currentWeapon.WeaponName== upgradeData.weaponName)
            {
                weaponToUpgrade = currentWeapon;
            }
        }
        if (weaponToUpgrade != null)
        {
            weaponToUpgrade.Upgrade(upgradeData);
        }
        else
        {
            Debug.Log("Weapon not found!");
        }
    }
}
