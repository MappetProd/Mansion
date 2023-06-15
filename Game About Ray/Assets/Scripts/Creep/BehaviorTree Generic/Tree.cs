using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class BTree : MonoBehaviour
    {
        private Node _root;

        private Coroutine _behavior;

        public Dictionary<string, object> data;

        private bool _isStartedBehavior;

        void Start()
        {
            data = new Dictionary<string, object>();
            _isStartedBehavior = false;
            _root = SetupTree();
        }

        void Update()
        {
            if (!_isStartedBehavior)
            {
                StartCoroutine(RunBehavior());
                _isStartedBehavior = true;
            }
        }

        private IEnumerator RunBehavior()
        {
            NodeState state = _root.Evaluate();
            while (state == NodeState.RUNNING)
            {
                yield return null;
                state = _root.Evaluate();
            }
        }

        protected abstract Node SetupTree();
    }
}

