using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio.BeheviourTree 
{
    public class Sequence : Node
    {
        public Sequence() : base() { }

        public Sequence(List<Node> children) : base(children)
        {

        }

        public override NodeState Evaluate()
        {
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        continue;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }
    }
}
