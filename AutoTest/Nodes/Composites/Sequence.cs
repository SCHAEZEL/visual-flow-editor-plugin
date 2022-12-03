using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Composites/Sequence")]
    public class Sequence : CompositeGraphNode
    {
        // protected override BehaviourTreeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index)
        // {
        //     return new Sequence() as BehaviourTreeNode<T>;
        // }
    }
}