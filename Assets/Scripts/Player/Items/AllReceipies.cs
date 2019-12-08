using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllReceipies : MonoBehaviour
{
    public static AllReceipies instance;

    public List<CraftableItemSO> craftableItemSOs = new List<CraftableItemSO>();

    private void Awake()
    {
        instance = GetComponent<AllReceipies>();

    }

    public static CraftableItemSO CheckReceipy(List<Item> items)
    {
        foreach (CraftableItemSO item in instance.craftableItemSOs)
        {
            if (item.reciepy.Count == items.Count) {
                int a = 0;
                for (int i = 0; i < items.Count; i++)
                {
                    for (int j = 0; j < items.Count; j++)
                    {
                        if(items[i].ItemName == item.reciepy[j].item.itemName)
                        {
                            if(items[i].amount == item.reciepy[j].Amount)
                                a++;
                            continue;
                        }

                    }
                }
                if(a == items.Count)
                {
                    return item;
                }
            }
        }
        return null;

    }

    public static CraftableItemSO GetCraftableItemByName(string itemName)
    {
        foreach (CraftableItemSO item in instance.craftableItemSOs)
        {
            if(item.itemName == itemName)
            {
                return item;
            }
        }
        return null;
    }
}
