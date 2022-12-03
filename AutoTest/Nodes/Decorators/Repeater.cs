using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/Repeater")]
    public class Repeater : DecoratorGraphNode
    {
        // protected override BehaviourTreeNode<T> BuildNode<T>(BehaviourTreeNode<T> child, int nodeIndex)
        // {
        //     return new Repeater() as BehaviourTreeNode<T>;
        // }
    }
}