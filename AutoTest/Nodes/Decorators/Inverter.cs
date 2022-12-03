using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/Inverter")]
    public class Inverter : DecoratorGraphNode
    {
        protected override BehaviourTreeNode<T> BuildNode<T>(BehaviourTreeNode<T> child, int nodeIndex)
        {
            return new Inverter() as BehaviourTreeNode<T>;
        }
    }
}