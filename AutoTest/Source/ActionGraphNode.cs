using System;
using UnityEngine;

namespace XNode.AutoTest
{
    [NodeTint("#2e4e6b")]
    public abstract class ActionGraphNode : BehaviourTreeGraphNode
    {
        [SerializeField, Input] public BehaviourTreeGraphConnection input;
        [SerializeField, Output] public BehaviourTreeGraphConnection output;
        [SerializeField] public string nodeId;
        protected string scope = "node";
        const string ChildrenPortNameFormat = "children {0}";
        const string UidFormat = "ActionNode_{0}";

        /// <summary> 总Action节点个数 </summary>
        static int nodeCount = 0;
        int childrenCount;

        public override int Size
        {
            get
            {
                var size = 0;
                for (var i = 0; i < childrenCount; i++)
                {
                    var port = GetOutputPort(string.Format(ChildrenPortNameFormat, i));
                    var connectedNode = port.Connection.node as BehaviourTreeGraphNode;
                    if (connectedNode == null) continue;
                    size += connectedNode.Size;
                }
                return size + 1;
            }
        }

        public override string GetNodeScope()
        {
            return scope;
        }

        protected override void Init()
        {
            base.Init();
            // Calculate children count.
            // note: it appears that xNode doesn't populate the children list on init.
            // Which results in children.Count being 0.
            childrenCount = 0;
            while (true)
            {
                var port = GetOutputPort(string.Format(ChildrenPortNameFormat, childrenCount));
                if (port == null) break;
                childrenCount++;
            }

            nodeCount++;
            nodeId = string.Format(UidFormat, nodeCount);
        }
    }
}