using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public Transform CellHolder;

    public List<Cell> cellInShop = new List<Cell>();

    public List<ItemSO> Primaries = new List<ItemSO>();
    public Dictionary<string, int> BuyingPrimaryPrice = new Dictionary<string, int>();
    public Dictionary<string, int> SellingPrimaryPrice = new Dictionary<string, int>();
    public Dictionary<string, int> SellinCraftablePrice = new Dictionary<string, int>();

    private void Awake()
    {
        instance = GetComponent<ShopManager>();
    }



    private void Start()
    {
        GenerateDictionaries();
        GenerateShop();
    }

    void GenerateDictionaries()
    {
        for (int i = 0; i < Primaries.Count; i++)
        {
            BuyingPrimaryPrice.Add(Primaries[i].itemName, 10);
            SellingPrimaryPrice.Add(Primaries[i].itemName, 5);
        }

        for (int i = 0; i < AllReceipies.instance.craftableItemSOs.Count; i++)
        {
            SellinCraftablePrice.Add(AllReceipies.instance.craftableItemSOs[i].itemName, 10);
        }
    }

    public void GenerateShop()
    {
        for (int i = 0; i < Primaries.Count; i++)
        {
            Cell newCell = CellGenerator.instance.AddNewCell(new Item(Primaries[i].itemName, 0), CellHolder);
            cellInShop.Add(newCell);
            newCell.currentCellState = Cell.cellState.inShop;
        }
    }

    
}
