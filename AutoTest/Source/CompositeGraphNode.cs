using System.Collections.Generic;
using UnityEngine;

namespace XNode.AutoTest
{
    [NodeTint("#2f4f32")]
    [NodeWidth(250)]

    public abstract class CompositeGraphNode : BehaviourTreeGraphNode
    {
        [SerializeField, Input] public BehaviourTreeGraphConnection parent;
        int nodeIndex;
        public string description = "复合节点";
        public override string nodeName => "DefaultNode";
        public override string scope => "node";
        const string IdFormat = "CompositeNode_{0}";
        public override string id => string.Format(IdFormat, nodeIndex);
        const string ChildrenPortNameFormat = "children {0}";
        static int compositeNodeCount = 0;
        [SerializeField, Output(dynamicPortList = true)] List<BehaviourTreeGraphConnection> children;
        int childrenCount;
        public override NodeType nodeType => NodeType.CompositeNode;

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
            compositeNodeCount++;
            nodeIndex = compositeNodeCount;
        }
    }
}