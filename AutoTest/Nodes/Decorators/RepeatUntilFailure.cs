using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/RepeatUntilFailure")]
    public class RepeatUntilFailure : DecoratorGraphNode
    {
        protected override BehaviourTreeNode<T> BuildNode<T>(BehaviourTreeNode<T> child, int nodeIndex)
        {
            return new RepeatUntilFailure() as BehaviourTreeNode<T>;
        }
    }
}