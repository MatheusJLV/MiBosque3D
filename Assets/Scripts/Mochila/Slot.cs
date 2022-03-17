using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler
{
    public Database database;
    public Image itemImage;
    public Text amountText;
    public Text message;
    public GameObject feedback;

    public SlotInfo slotInfo;

    public void SetUp(int id)
    {
        slotInfo = new SlotInfo();
        slotInfo.id = id;
        slotInfo.EmptySlot();
    }

    public void UpdateUI()
    {
        
        if (slotInfo.isEmpty)
        {
            itemImage.sprite = null;
            itemImage.enabled = false;
        }
        else
        {
            
            itemImage.sprite = database.FindItemInDatabase(slotInfo.itemId).itemImage;
            itemImage.enabled = true;
            
            if (slotInfo.amount > 1)
            {
                amountText.text = slotInfo.amount.ToString();
                amountText.gameObject.SetActive(true);
            }
            else
                amountText.gameObject.SetActive(false);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        DragNDrop DnD = eventData.pointerDrag.GetComponent<DragNDrop>();
        DnD.destinationSlot = this;
    }


}
[System.Serializable]
public class SlotInfo
{
    public int id;
    public bool isEmpty;
    public int itemId;
    public int amount;
    public int maxAmount = 3;

    public void EmptySlot()
    {
        isEmpty = true;
        amount = 0;
        itemId = -1;
    }
}
