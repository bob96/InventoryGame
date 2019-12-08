using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    private Cell currentCell;
    public Text ButtonText;

    private void Start()
    {
        currentCell = GetComponent<Cell>();
    }

    private void Update()
    {
        switch (currentCell.currentCellState)
        {
            case Cell.cellState.inInventory:
                if(ShopManager.instance.SellingPrimaryPrice.ContainsKey(currentCell.ItemReference.ItemName))
                    currentCell.ItemReference.price = ShopManager.instance.SellingPrimaryPrice[currentCell.ItemReference.ItemName];
                else if(ShopManager.instance.SellinCraftablePrice.ContainsKey(currentCell.ItemReference.ItemName))
                    currentCell.ItemReference.price = ShopManager.instance.SellinCraftablePrice[currentCell.ItemReference.ItemName];
                ButtonText.text = "-";
                break;
            case Cell.cellState.inCraftingTable:
                currentCell.ItemPrice.gameObject.SetActive(false);
                ButtonText.transform.parent.gameObject.SetActive(false);
                break;
            case Cell.cellState.inShop:
                currentCell.ItemAmount.gameObject.SetActive(false);
                if (ShopManager.instance.BuyingPrimaryPrice.ContainsKey(currentCell.ItemReference.ItemName))
                    currentCell.ItemReference.price = ShopManager.instance.BuyingPrimaryPrice[currentCell.ItemReference.ItemName];
                ButtonText.text = "+";
                break;
            case Cell.cellState.inResult:
                currentCell.ItemPrice.gameObject.SetActive(false);
                ButtonText.transform.parent.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
