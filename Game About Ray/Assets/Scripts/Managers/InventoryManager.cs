using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _inventorySlots;
    [SerializeField] private GameObject _inventoryItemPrefab;
    public void AddItem(Item item)
    {
        /*funtion finds first free slot, and spawn item there */
        for (int i = 0; i < _inventorySlots.Length; i++) 
        {
            GameObject slot = _inventorySlots[i]; //current slot
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null) //if current slot doesn't have children (items) than this slot is empty
            {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    private void SpawnNewItem(Item item, GameObject slot)
    {
        GameObject newItemGameObject = Instantiate(_inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGameObject.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item); //init fields of item
    }

    public GameObject FindItem(Item item)
    {
        for (int i = 0; i <_inventorySlots.Length; i++) 
        { 
            GameObject currentSlot = _inventorySlots[i];
            InventoryItem itemInCurrSlot = currentSlot.GetComponentInChildren<InventoryItem>();
            if (currentSlot.GetComponentInChildren<InventoryItem>() == null)
                continue;
            else
            {
                if (itemInCurrSlot.item == item)
                    return itemInCurrSlot.gameObject;
            }
        }
        return null;
    }

    public bool DeleteItem(Item item)
    {
        GameObject deleteObj = FindItem(item);
        if (deleteObj != null)
        {
            Destroy(deleteObj);
            return true;
        }
        else
            return false;
    }
}
