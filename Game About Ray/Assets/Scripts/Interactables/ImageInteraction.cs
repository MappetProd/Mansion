using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private Item item; //prefab of artifact, note or painting
    [SerializeField] private PuzzleVariables _puzzleDB;
    [SerializeField] private int numberOfPuzzle; //number of puzzle, that is linked to current object

    [Header("UI")]
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private string _notificationExitText; //text to end activitity, that was inititiated ("Press E to exit...")

    private GameObject itemObj = null; //artifact, image or note, that a player interacted with

    public void Interact(PlayerSM _sm)
    {
        if (itemObj != null) //if player views item, function won't work
            return;

        _uiManager.playerController.enabled = false; //make a player not move
        _uiManager.playerController.rb.velocity = Vector3.zero; //bug fix: player continues moving after interaction;

        /*create empty gameobject in canvas*/
        itemObj = Instantiate(item.prefabOfObj, _uiManager.canvas.transform);

        _uiManager.blackBackground.SetActive(true); //make efftect of darker background 
        _uiManager.toolbar.SetActive(false); //turn off the toolbar
        _uiManager.bottomNotificationText.SetActive(false);
        /*_uiManager.bottomNotificationText.GetComponent<Text>().text = _notificationExitText; //*/
    }

    private void Update()
    {
        if (gameObject.CompareTag("Puzzle") && _puzzleDB.puzzlesIsSolvedDict[numberOfPuzzle])
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        if (itemObj != null)
            if (Input.GetKeyDown(KeyCode.Escape)) //if player views item AND press Escape, activity'll be stopped;
            {
                Destroy(itemObj);
                _uiManager.playerController.enabled = true;
                _uiManager.blackBackground.SetActive(false);
                _uiManager.toolbar.SetActive(true);
            }
    }
}
