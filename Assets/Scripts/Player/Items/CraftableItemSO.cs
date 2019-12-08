using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CraftableItemSO : ItemSO
{
    public List<CraftableItem> reciepy = new List<CraftableItem>();
    public int gain;
}

[System.Serializable]
public struct CraftableItem
{
    public ItemSO item;
    public int Amount;
}
