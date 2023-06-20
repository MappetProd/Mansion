using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.UI;

public class CheckIfTimerOut : Node
{
    private float _timer = 7f;
    public CheckIfTimerOut(BTree tree) : base(tree) { }

    public override NodeState Evaluate()
    {
        /*if (_timer < 10f)
        {
            ((CreepBT)tree).uiManager.topNotificationText.SetActive(true);
            ((CreepBT)tree).uiManager.topNotificationText.GetComponent<Text>().text = "Creep появится через " + Mathf.CeilToInt(_timer) + " секунд!";
        }*/
        _timer -= Time.deltaTime;
        if ( _timer < 0)
        {
            state = NodeState.FAILURE;
            //((CreepBT)tree).uiManager.topNotificationText.SetActive(false);
            _timer = 7f;
        }
        else
        {
            state = NodeState.RUNNING;
        }

        return state;
    }

}
