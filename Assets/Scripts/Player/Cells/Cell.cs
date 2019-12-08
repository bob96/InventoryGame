using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cell : MonoBehaviour, IItem
{
    public Text ItemName;
    public Text ItemAmount;
    public Text ItemPrice;

    public Item ItemReference;
    
    public enum cellState
    {
        inInventory,
        inCraftingTable,
        inShop,
        inResult
    }

    public cellState currentCellState;

    private void Update()
    {
        ItemAmount.text = ItemReference.amount.ToString();
        ItemName.text = ItemReference.ItemName;
        ItemPrice.text = ItemReference.price.ToString();
        if(ItemReference.amount == 0 && currentCellState != cellState.inShop)
        {
            CraftingTableManager.instance.cells.Remove(GetComponent<Cell>());
            CellGenerator.InventoryCells.Remove(GetComponent<Cell>());
            Destroy(this.gameObject);
        }
    }

    public void ChangeAmount(int amount)
    {
        ItemReference.amount = amount;
        
    }

    public void ChangeName(string itemName)
    {
        ItemReference.ItemName = itemName;
    }

    public void ChangeReference(string itemName, int amount)
    {
        ChangeAmount(amount);
        ChangeName(itemName);
    }

    public void BuyAndSellItem()
    {
        if(currentCellState == cellState.inShop)
        {
            //buy
            Debug.Log(ItemReference.price);
            if(PlayerBank.instance.currentCoins >= ItemReference.price)
            {
                StartCoroutine(PlayerBank.instance.UpdateCoinText(ItemReference.price, -1));
                AddToInventory();
            }

        }
        else if(currentCellState == cellState.inInventory)
        {
            //sell
            StartCoroutine(PlayerBank.instance.UpdateCoinText(ItemReference.price, 1));
            if(ItemReference.amount >= 1)
            {
                ItemReference.amount--;
            }
            
        }
    }


    public void AddToInventory()
    {
        Cell MyCell = GetComponent<Cell>();
        foreach (Cell item in CellGenerator.InventoryCells)
        {
            if (MyCell.ItemName.text == item.ItemReference.ItemName)
            {
               
                item.ItemReference.amount++;
                Debug.Log(MyCell.ItemReference.ItemName);
                return;
            }
        }
        Cell cell = CellGenerator.instance.AddNewCell(new Item(MyCell.ItemReference.ItemName, 1), CellGenerator.instance.CellHolder);
        cell.currentCellState = Cell.cellState.inInventory;
        CellGenerator.InventoryCells.Add(cell);
        cell.gameObject.AddComponent<AddtoCraftingTable>();
    }

}
