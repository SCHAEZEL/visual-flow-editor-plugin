
namespace XNode.AutoTest
{
    [CreateNodeMenu("Composites/MemSequence")]
    public class MemSequence : CompositeGraphNode
    {
        public override string description => "带优先级顺序节点";

        public override object GetValue(NodePort port) {
            return null; 
        }
    }
}