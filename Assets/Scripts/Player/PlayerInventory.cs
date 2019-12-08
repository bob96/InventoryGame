using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    public List<CraftableItem> StartingItems = new List<CraftableItem>();

    public static List<Item> items = new List<Item>();

    public static bool itemGeneratedToList = false;
    private void Awake()
    {
        instance = GetComponent<PlayerInventory>();
    }

    private void Start()
    {
        GenerateItemsToInventory();
    }

    void GenerateItemsToInventory()
    {
        items.Clear();
        foreach (CraftableItem item in StartingItems)
        {
            items.Add(new Item(item.item.itemName, item.Amount));
        }
        itemGeneratedToList = true;
    }

    
}


