using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.AutoTest
{
    [NodeTint("#6b2e53")]
    public abstract class DecoratorGraphNode : BehaviourTreeGraphNode
    {
        [SerializeField, Input] public BehaviourTreeGraphConnection input;
        [SerializeField, Output] public BehaviourTreeGraphConnection output;
        [SerializeField] public string nodeId;
        protected string scope = "node";
        const string UidFormat = "CompositeNode_{0}";
        const string ChildPortNameFormat = "child";
        const string ChildrenPortNameFormat = "children {0}";

        /// <summary> 总Action节点个数 </summary>
        static int nodeCount = 0;
        int childrenCount;

        public override int Size
        {
            get
            {
                var port = GetOutputPort(string.Format(ChildPortNameFormat));
                var connectedNode = port.Connection.node as BehaviourTreeGraphNode;
                return connectedNode == null ? 1 : connectedNode.Size + 1;
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