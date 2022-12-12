
namespace XNode.AutoTest
{
    [CreateNodeMenu("Composites/Sequence")]
    public class Sequence : CompositeGraphNode
    {
        public override string description => "顺序执行";

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}