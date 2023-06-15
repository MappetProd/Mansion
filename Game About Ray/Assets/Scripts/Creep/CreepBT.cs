using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepBT : BTree
{
    public Transform[] waypoints;
    public float timeForOccurance = 3f;

    protected override Node SetupTree()
    {
        Node root = new Repeater(this, 
                        new Sequence(this, new List<Node> { 
                            new Invertor(this, 
                                new RepeatTillFail(this, 
                                    new CheckIfTimerOut(this))),
                            new TaskPatrol(this)})
                    );
        return root;
    }
}
