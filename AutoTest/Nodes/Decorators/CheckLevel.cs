using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/CheckLevel")]
    public class CheckLevel : DecoratorGraphNode
    {
        protected override BehaviourTreeNode<T> BuildNode<T>(BehaviourTreeNode<T> child, int nodeIndex)
        {
            return new CheckLevel() as BehaviourTreeNode<T>;
        }
    }
}