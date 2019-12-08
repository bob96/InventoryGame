using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGenerator : MonoBehaviour
{
    public static CellGenerator instance;

    public GameObject CellsPrefab;
    public Transform CellHolder;

    public static List<Cell> InventoryCells = new List<Cell>();

    


    public float TimeInBetween = 1.0f;

    private void Awake()
    {
        instance = GetComponent<CellGenerator>();
    }

    private void Start()
    {
        StartCoroutine(GenerateCells());
    }

    public IEnumerator GenerateCells()
    {
        while(!PlayerInventory.itemGeneratedToList)
            yield return new WaitForEndOfFrame();
        foreach (Item item in PlayerInventory.items)
        {
            Cell newCell = AddNewCell(item, CellHolder); // this allows as to know if the cell is in the inventory
            newCell.currentCellState = Cell.cellState.inInventory;
            InventoryCells.Add(newCell);
            newCell.gameObject.AddComponent<AddtoCraftingTable>();
            yield return new WaitForSeconds(TimeInBetween);
        }
    }

    public static Cell GetItemByName(string itemName)
    {
        foreach (Cell item in InventoryCells)
        {
            if (item.ItemReference.ItemName == itemName)
            {
                return item;
            }
        }
        return null;
    }

    public Cell AddNewCell(Item item, Transform CellHolder)
    {
        GameObject newCell = Instantiate(CellsPrefab, CellHolder);
        IItem itemAccesser = newCell.GetComponent<IItem>();
        itemAccesser.ChangeName(item.ItemName);
        itemAccesser.ChangeAmount(item.amount);
        itemAccesser.ChangeReference(item.ItemName, item.amount);
        
        
        return newCell.GetComponent<Cell>();
    }


}
