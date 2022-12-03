using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/RepeatUntilSuccess")]
    public class RepeatUntilSuccess : DecoratorGraphNode
    {
        // protected override BehaviourTreeNode<T> BuildNode<T>(BehaviourTreeNode<T> child, int nodeIndex)
        // {
        //     return new RepeatUntilSuccess() as BehaviourTreeNode<T>;
        // }
    }
}