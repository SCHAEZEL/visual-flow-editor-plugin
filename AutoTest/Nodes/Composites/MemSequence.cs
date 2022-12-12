
namespace XNode.AutoTest
{
    [CreateNodeMenu("Composites/MemSequence")]
    public class MemSequence : CompositeGraphNode
    {
        public override string description => "顺序执行(优先执行上一轮次节点)";

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}