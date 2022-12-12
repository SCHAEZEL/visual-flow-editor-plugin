using System.Collections.Generic;
using UnityEngine;

namespace XNode.AutoTest
{
    [NodeTint("#2f4f32")]
    [NodeWidth(250)]

    public abstract class CompositeGraphNode : BehaviourTreeGraphNode
    {
        [SerializeField, Input] public BehaviourTreeGraphConnection parent;
        public string title;
        int nodeIndex;

        /// <summary> 用于导出后查看节点备注 </summary>
        public override string description => "复合节点";
        public override string nodeName => "DefaultNodeName";
        public override string scope => "node";
        const string IdFormat = "CompositeNode_{0}";
        public override string id => string.Format(IdFormat, nodeIndex);
        static int compositeNodeCount = 0;
        [SerializeField, Output(dynamicPortList = true)] List<BehaviourTreeGraphConnection> children;
        int childrenCount;
        public override NodeType nodeType => NodeType.CompositeNode;
        public override bool isEnableDynamicPort => true;

        public override int Size
        {
            get
            {
                var size = 0;
                for (var i = 0; i < children.Count; i++)
                {
                    BehaviourTreeGraphNode connectedNode = GetChildAt(i);
                    if (connectedNode == null) continue;
                    size++;
                }
                return size == 0 ? -1 : size;
            }
        }

        protected override void Init()
        {
            base.Init();
            childrenCount = 0;
            while (true)
            {
                var port = GetOutputPort(string.Format(AutoTestDefine.ChildrenPortNameFormat, childrenCount));
                if (port == null) break;
                childrenCount++;
            }
            title = description;
            compositeNodeCount++;
            nodeIndex = compositeNodeCount;
        }
    }
}