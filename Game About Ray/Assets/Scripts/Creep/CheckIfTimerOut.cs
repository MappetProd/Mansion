using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckIfTimerOut : Node
{
    private float _timer = 3f;
    public CheckIfTimerOut(BTree tree) : base(tree) { }

    public override NodeState Evaluate()
    {
        _timer -= Time.deltaTime;
        if ( _timer < 0)
        {
            state = NodeState.FAILURE;
            _timer = 3f;
        }
        else
        {
            state = NodeState.RUNNING;
        }

        return state;
    }

}
