using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGoAway : Node
{
    private CreepBT _tree;
    public TaskGoAway(BTree tree) : base(tree) 
    {
        _tree = (CreepBT)tree;
    }

}
