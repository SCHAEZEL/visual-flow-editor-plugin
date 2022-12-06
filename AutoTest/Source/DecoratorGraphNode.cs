using UnityEditor;
using UnityEngine;

namespace XNode.AutoTest
{
    [NodeTint("#6b2e53")]
    public abstract class DecoratorGraphNode : BehaviourTreeGraphNode
    {
        [SerializeField, Input] public BehaviourTreeGraphConnection parent;
        [SerializeField, Output] public BehaviourTreeGraphConnection child;
        int nodeIndex;
        public override string description => "装饰器节点";
        public override string nodeName => "DefaultDecoratorNode";
        public override string scope => "node";
        const string IdFormat = "DecoratorNode_{0}";
        public override string id => string.Format(IdFormat, nodeIndex);

        static int decoratorNodeCount = 0;
        int childrenCount;
        public override NodeType nodeType => NodeType.DecoratorNode;
        protected override void Init()
        {
            base.Init();
            // Calculate children count.
            // note: it appears that xNode doesn't populate the children list on init.
            // Which results in children.Count being 0.
            childrenCount = 0;
            while (true)
            {
                var port = GetOutputPort(string.Format(AutoTestDefine.ChildrenPortNameFormat, childrenCount));
                if (port == null) break;
                childrenCount++;
            }
            decoratorNodeCount++;
            nodeIndex = decoratorNodeCount;
        }
    }
}