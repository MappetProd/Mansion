using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*A singleton that contains all UI references*/
public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [HideInInspector] public GameObject canvas { get; private set; }
    [HideInInspector] public GameObject toolbar { get; private set; } //UI toolbar reference
    [HideInInspector] public PlayerSM playerController { get; private set; } //player controller
    [HideInInspector] public GameObject bottomNotificationText { get; private set; } //"Press E to..." text
    [HideInInspector] public GameObject topNotificationText { get; private set; }
    [HideInInspector] public GameObject blackBackground { get; private set; } //makes backround darker when player views image/note

    private void Awake()
    {
        if (instance == null)
            instance = this;

        /*get all UI references*/
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        toolbar = GameObject.Find("Toolbar");
        playerController = GameObject.Find("Player").GetComponent<PlayerSM>();
        bottomNotificationText = GameObject.Find("bottomNotificationText");
        topNotificationText = GameObject.Find("topNotificationText");
        blackBackground = GameObject.Find("darkBackground");

        /*Unity can't find inactive objects, so when Awake function works, some UI elements need to be active.
         So there are some UI elements, that should be disabled by default*/
        bottomNotificationText.SetActive(false);
        topNotificationText.SetActive(false);
        blackBackground.SetActive(false);
    }
}
