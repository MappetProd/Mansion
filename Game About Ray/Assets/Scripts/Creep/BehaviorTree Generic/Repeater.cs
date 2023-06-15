using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Repeater : Decorator
    {
        public Repeater(BTree tree, Node child): base(tree, child) { }

        public override NodeState Evaluate()
        {
            state = NodeState.RUNNING;
            return state;
        }
    }
}

