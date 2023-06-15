using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Invertor : Decorator
    {
        public Invertor(BTree tree, Node child) : base (tree, child) { }

        public override NodeState Evaluate()
        {
            switch (child.Evaluate())
            {
                case NodeState.SUCCESS:
                    state = NodeState.FAILURE;
                    break;
                case NodeState.FAILURE:
                    state = NodeState.SUCCESS;
                    break;
                case NodeState.RUNNING:
                    state = NodeState.RUNNING;
                    break;
            }
            return state;
        }
    }
}

