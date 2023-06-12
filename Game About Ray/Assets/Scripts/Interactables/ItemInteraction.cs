using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] Item itemToTake; //item that contains in object and meant to be taken by Player
    public void Interact(PlayerSM stateMachine)
    {
        inventoryManager.AddItem(itemToTake);
        GetComponent<BoxCollider2D>().enabled = false; //player can't interact with this obj anymore after turning off the collider
    }
}
