using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Composites/Selector")]
    public class Selector : CompositeGraphNode
    {
        protected override BehaviourTreeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index)
        {
            return new Selector() as BehaviourTreeNode<T>;
        }
    }
}