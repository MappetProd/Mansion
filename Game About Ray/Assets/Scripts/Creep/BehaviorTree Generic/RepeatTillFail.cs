using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class RepeatTillFail : Decorator
    {
        public RepeatTillFail(BTree tree, Node child) : base(tree, child) { }

        public override NodeState Evaluate()
        {
            switch (child.Evaluate())
            {
                case NodeState.FAILURE:
                    state = NodeState.FAILURE;
                    break;
                case NodeState.SUCCESS:
                    state = NodeState.RUNNING;
                    break;
                case NodeState.RUNNING:
                    state = NodeState.RUNNING;
                    break;
            }
            return state;
        }
    }
}

