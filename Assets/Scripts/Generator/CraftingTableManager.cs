using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTableManager : MonoBehaviour
{
    public static CraftingTableManager instance;

    public Transform cellHolder;
    public GameObject cellPrefab;
    public int maxCells =  5;

    public List<Cell> cells = new List<Cell>();

    private void Awake()
    {
        instance = GetComponent<CraftingTableManager>();
    }

    public void AddItemToCraftingTable(string itemName)
    {
        foreach (Cell cell in cells)
        {
            if(cell.ItemReference.ItemName == itemName)
            {
                cell.ItemReference.amount++;
                return;
            }
        }
        if(cells.Count >= 5)
        {
            Debug.Log("maximum cells reached");
            return;
        }
        else
        {
            GameObject newCell = Instantiate(cellPrefab, cellHolder);
            IItem itemAccesser = newCell.GetComponent<IItem>();
            itemAccesser.ChangeName(itemName);
            itemAccesser.ChangeAmount(1);
            itemAccesser.ChangeReference(itemName, 1);
            cells.Add(newCell.GetComponent<Cell>());
            newCell.AddComponent<RetrunToInventory>();
            newCell.GetComponent<Cell>().currentCellState = Cell.cellState.inCraftingTable;
        }
        


    }

    public void CheckReceipy()
    {
        List<Item> items = new List<Item>();
        foreach (Cell item in cells)
        {
            items.Add(item.ItemReference);
        }

        CraftableItemSO validItem = AllReceipies.CheckReceipy(items);
        Debug.Log(validItem);
        if (validItem == null)
        {
            return;
        }
        Item resultItem = new Item(validItem.itemName, 1);

        REsultManager.instance.UpdateItemResult(resultItem);

        cells.Clear();
        foreach (Transform Child in cellHolder)
        {
            Destroy(Child.gameObject);
        }

        
    }

}

public class CraftingTableCell
{
    public string itemName;
    public GameObject Cell;
    public int amount;

    public CraftingTableCell(string itemName, GameObject Cell,int amount)
    {
        this.itemName = itemName;
        this.Cell = Cell;
        this.amount = amount;
    }

}
