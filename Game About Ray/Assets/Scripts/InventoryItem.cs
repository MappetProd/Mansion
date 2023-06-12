using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{
    [Header("UI")]
    public Image image;

    [HideInInspector] public Item item;
    //[HideInInspector] public Transform parentAfterDrag;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.prefabOfObj.GetComponent<Image>().sprite;
    }
}
