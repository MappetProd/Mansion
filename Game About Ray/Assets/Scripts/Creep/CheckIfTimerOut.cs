using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckIfTimerOut : Node
{
    public CheckIfTimerOut(BTree tree) : base(tree) { }

    public override NodeState Evaluate()
    {
        return state;
    }


}
