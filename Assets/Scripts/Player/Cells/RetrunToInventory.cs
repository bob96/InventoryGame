using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class RetrunToInventory : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Cell MyCell = GetComponent<Cell>();
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            MyCell.AddToInventory();
            MyCell.ItemReference.amount--;
        }
    }
}
