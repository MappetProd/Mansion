using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Node
    {

        protected BTree tree;
        public NodeState state;
        public Node(BTree tree)
        {
            this.tree = tree;
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;
    }

    public enum NodeState
    {
        SUCCESS,
        FAILURE,
        RUNNING
    }
}
