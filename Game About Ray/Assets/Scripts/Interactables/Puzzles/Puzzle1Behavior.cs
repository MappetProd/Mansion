using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle1Behavior : MonoBehaviour
{
    private UIManager _uiManager;
    [SerializeField] private PuzzleVariables _puzzleDB;

    [SerializeField]
    private string _winText;
    [SerializeField]
    private string _loseText;

    [SerializeField]
    private Sprite[] _btnSpritesArray; //array of button sprites (5 colours)

    [SerializeField]
    private Sprite[] _ethalonArr = new Sprite[4]; //right sequence of colours (solution of puzzle)

    private Dictionary<string, int> _btnDict = new Dictionary<string, int>(); //dictionary of 

    private void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        for (int i = 1; i < 6; i++)
        {
            _btnDict[i.ToString()] = 1;
        }
    }

    public void ChangeColor()
    {
        GameObject currButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        currButton.GetComponent<Image>().sprite = _btnSpritesArray[_btnDict[currButton.name] % _btnSpritesArray.Length];

        _btnDict[currButton.name] += 1;
    }

    public void CheckIfPuzzleSolved()
    {
        //current sequence of colours, that player managed to set
        var _currentSequence = gameObject.GetComponentsInChildren<Image>().Where(x => x.gameObject != this.gameObject && x.name != "checkResultBtn");
        bool isSolved = true;

        int ethalonIndex = 0;
        foreach (var button in _currentSequence)
        {
            if (button.sprite != _ethalonArr[ethalonIndex])
            {
                isSolved = false;
                break;
            }
            ethalonIndex++;
        }

        GameObject topNotificationTextRef = _uiManager.topNotificationText;
        _uiManager.topNotificationText.SetActive(true);
        if (isSolved)
        {
            _puzzleDB.puzzlesIsSolvedDict[1] = true;
            topNotificationTextRef.GetComponent<Text>().text = _winText;

            _uiManager.blackBackground.SetActive(false);
            _uiManager.toolbar.SetActive(true);

            Destroy(gameObject);

            _uiManager.playerController.enabled = true;
        }
        else
        {
            topNotificationTextRef.GetComponent<Text>().text = _loseText;
        }
        /*Delay();
        _uiManager.topNotificationText.SetActive(false);*/
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
    }
}
