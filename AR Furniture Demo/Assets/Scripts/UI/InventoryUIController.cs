using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public List<GameObject> SlotsList;
    public int selectedItemID;
    public FurnitureInventory furnitureInventory;

    public void SetSelectedItemID(int id)
    {
        selectedItemID = id;
        furnitureInventory.SetObjectToPlace(selectedItemID);

        SetCheckBox();
    }

    public void SetCheckBox()
    {
        for(int i = 0; i < SlotsList.Count; i++)
        {
            SlotsList[i].GetComponent<EmptyItemSlot>().checkBox.SetActive(false);
        }
        SlotsList[selectedItemID].GetComponent<EmptyItemSlot>().checkBox.SetActive(true);
    }
}
