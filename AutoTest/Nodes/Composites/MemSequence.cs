using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Composites/MemSequence")]
    public class MemSequence : CompositeGraphNode
    {
        protected override BehaviourTreeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index)
        {
            return new MemSequence() as BehaviourTreeNode<T>;
        }
    }
}