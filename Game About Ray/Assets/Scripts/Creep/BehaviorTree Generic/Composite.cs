using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Composite : Node
    {
        protected List<Node> children;

        public Composite(List<Node> children, BTree tree) : base(tree)
        {
            this.children = children;
            this.tree = tree;
        }
    }
}

