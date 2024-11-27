using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

public class PassiveUpgrades : MonoBehaviour
{
    [SerializeField] List<Item> items;

    PlayerCharacterController player;


    private void Awake()
    {
        player = GetComponent<PlayerCharacterController>();
    }
/*    public void Equip(Item itemToEquip)
    {
        if(items == null)
        {
            items = new List<Item>();
        }
        items.Add(itemToEquip);
        itemToEquip.Equip(player);
    }*/

    public void UnEquip(Item itemToEquip)
    {

    }    
}
