using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Composites/MemPriority")]
    public class MemPriority : CompositeGraphNode
    {
        protected override CompositeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index)
        {
            return new MemPriority<T>(children, index);
        }
    }

}