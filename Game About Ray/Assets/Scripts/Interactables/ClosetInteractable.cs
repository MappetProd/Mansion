using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClosetInteractable : MonoBehaviour, IInteractable
{
    private bool isPlayerInLocker = false;

    [Header("Gameplay")]
    [SerializeField] private bool _locked; //Is closet locked by default?
    [SerializeField] private Item _itemForUnlock; //Item for unlocking closet

    [Header("UI")]
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private string _notificationExitText; //"Press "E" to leave the locker" message
    [SerializeField] private string _lockNotification; //"You need a key to unlock closet" message
    [SerializeField] private string _unlockNotification; // "Locker has opened!" message
    public void Interact(PlayerSM stateMachine)
    {
        if (!_locked)
        {
            _uiManager.playerController.enabled = false; //make a player not move
            _uiManager.playerController.rb.velocity = Vector3.zero; //bug fix: player continues moving after interaction;

            _uiManager.playerController.GetComponent<SpriteRenderer>().enabled = false; //make player's sprite invisible 
            _uiManager.playerController.GetComponent<Collider2D>().enabled = false; //turn off player's collider

            _uiManager.bottomNotificationText.SetActive(true); //set ui message active about
            _uiManager.bottomNotificationText.GetComponent<Text>().text = _notificationExitText;

            isPlayerInLocker = true;
            return;
        }


        if (_locked && stateMachine.inventoryManager.DeleteItem(_itemForUnlock))
        {
            _locked = false;
            _uiManager.topNotificationText.SetActive(true);
            _uiManager.topNotificationText.GetComponent<Text>().text = _unlockNotification;
        }
        else
        {
            _uiManager.bottomNotificationText.SetActive(true); //
            _uiManager.bottomNotificationText.GetComponent<Text>().text = _lockNotification;
        }
    }

    private void Update()
    {
        if (isPlayerInLocker)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPlayerInLocker = false;

                /*turn on all player's important functions*/
                _uiManager.playerController.enabled = true;
                _uiManager.playerController.GetComponent<SpriteRenderer>().enabled = true;
                _uiManager.playerController.GetComponent<Collider2D>().enabled = true;
            }
    }
}
