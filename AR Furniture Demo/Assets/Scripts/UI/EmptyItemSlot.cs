using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyItemSlot : MonoBehaviour
{
    public int slotID;
    [SerializeField] private int storedItemID;
    public GameObject Itemicon;
    //public Sprite itemIconSprite;
    public GameObject checkBox;
    public InventoryUIController inventoryUIController;

    public void SlotClicked()
    {
        inventoryUIController.SetSelectedItemID(slotID);
        Debug.Log("clicked");
    }


}
