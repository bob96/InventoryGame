using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REsultManager : MonoBehaviour
{
    public static REsultManager instance;

    public GameObject cellHolder;
    public GameObject cellPrefab;

    public static Cell resultCell;

    private void Awake()
    {
        instance = GetComponent<REsultManager>();
    }

    public void UpdateItemResult(Item Result)
    {
        GameObject newCell = Instantiate(cellPrefab, cellHolder.transform);
        resultCell = newCell.GetComponent<Cell>();
        newCell.AddComponent<RetrunToInventory>();
        CraftableItemSO ResultSO = AllReceipies.GetCraftableItemByName(Result.ItemName);
        StartCoroutine(PlayerBank.instance.UpdateCoinText(ResultSO.gain, +1));
        resultCell.ItemReference = Result;
    }
}
