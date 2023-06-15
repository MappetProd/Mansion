using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Decorator : Node
    {
        protected Node child;
        public Decorator(BTree tree, Node child) : base(tree)
        {
            this.tree = tree;
            this.child = child;
        }
    }
}

