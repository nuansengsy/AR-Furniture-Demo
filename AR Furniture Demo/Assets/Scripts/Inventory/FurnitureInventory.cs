using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int index;
    public GameObject modelPrefab;
}

public class FurnitureInventory : MonoBehaviour
{
    public static FurnitureInventory SharedInstance;
    public TapToPlace tapToPlace;
    public List<Item> itemsList;
    public GameObject objectToPlace;
    //public AsyncOperationHandle<GameObject> handle;

    private void Awake()
    {
        if (SharedInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            SharedInstance = this;
        }
    }
    void Start()
    {
        objectToPlace = itemsList[0].modelPrefab;
    }

    public void SetObjectToPlace(int id)
    {
        objectToPlace = itemsList[id].modelPrefab;
        tapToPlace.ChangeItem();
    }
}
