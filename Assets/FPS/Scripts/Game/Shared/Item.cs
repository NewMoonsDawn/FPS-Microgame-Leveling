using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField]
    public string itemName;
    [SerializeField]
    public float armor;
    [SerializeField]
    public float health;
    [SerializeField]
    public float speed;
    [SerializeField]
    public UpgradeData nextLevel;

}
