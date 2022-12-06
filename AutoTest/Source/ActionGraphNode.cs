using System;
using UnityEngine;

namespace XNode.AutoTest
{
    [NodeTint("#2e4e6b")]
    public abstract class ActionGraphNode : BehaviourTreeGraphNode
    {
        [SerializeField, Input] public BehaviourTreeGraphConnection parent;
        [SerializeField, Output] public BehaviourTreeGraphConnection child;
        int nodeIndex;
        public string description = "行为节点";
        const string ChildrenPortNameFormat = "children {0}";
        public override string scope => "node";
        const string IdFormat = "ActionNode_{0}";
        public override string id => string.Format(IdFormat, nodeIndex);
        static int actionNodeCount = 0;
        int childrenCount;
        public override NodeType nodeType => NodeType.ActionNode;

        protected override void Init()
        {
            base.Init();
            childrenCount = 0;
            while (true)
            {
                var port = GetOutputPort(string.Format(ChildrenPortNameFormat, childrenCount));
                if (port == null) break;
                childrenCount++;
            }

            actionNodeCount++;
            nodeIndex = actionNodeCount;
        }
    }
}