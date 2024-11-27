using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.FPS.Game;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text upgradeName;


    public void Set(UpgradeData upgradeData)
    {
        upgradeName.text = upgradeData.upgradeName;
        description.text = upgradeData.description; ;
    }

    internal void Clean()
    {
        upgradeName.text = null;
        description.text = "Out of Upgrades!";
    }
}
