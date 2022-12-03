using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/Limiter")]
    public class Limiter : DecoratorGraphNode
    {
        // protected override BehaviourTreeNode<T> BuildNode<T>(BehaviourTreeNode<T> child, int nodeIndex)
        // {
        //     return new Limiter() as BehaviourTreeNode<T>;
        // }
    }
}