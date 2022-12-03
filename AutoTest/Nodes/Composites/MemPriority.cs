using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Composites/MemPriority")]
    public class MemPriority : CompositeGraphNode
    {
        protected override BehaviourTreeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index)
        {
            return new MemPriority() as BehaviourTreeNode<T>;
        }
    }

}