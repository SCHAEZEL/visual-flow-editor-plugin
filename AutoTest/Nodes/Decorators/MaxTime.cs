using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/MaxTime")]
    public class MaxTime : DecoratorGraphNode
    {
        protected override BehaviourTreeNode<T> BuildNode<T>(BehaviourTreeNode<T> child, int nodeIndex)
        {
            return new MaxTime() as BehaviourTreeNode<T>;
        }
    }
}