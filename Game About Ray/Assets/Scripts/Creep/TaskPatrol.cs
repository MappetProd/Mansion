using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System.Linq;

public class TaskPatrol : Node
{
    private List<Transform> tempWaypoints;

    public TaskPatrol(BTree tree) : base(tree) { }

    public override NodeState Evaluate()
    {
        return state;
    }

    private void InitWaypoints()
    {
        tempWaypoints = ((CreepBT)tree).waypoints.ToList();
    }

    private void TagWaypoint()
    {
        
    }
}
