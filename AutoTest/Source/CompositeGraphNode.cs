using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.AutoTest
{
    [NodeTint("#2f4f32")]
    [NodeWidth(250)]

    public abstract class CompositeGraphNode : BehaviourTreeGraphNode
    {
        [SerializeField, Input] public BehaviourTreeGraphConnection input;
        [SerializeField] public string nodeId;
        [SerializeField, Output(dynamicPortList = true)] List<BehaviourTreeGraphConnection> children;
        // [SerializeField, Output] public BehaviourTreeGraphConnection output;

        protected string scope = "node";
        const string ChildrenPortNameFormat = "children {0}";
        const string UidFormat = "CompositeNode_{0}";

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