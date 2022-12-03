using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Composites/MemSequence")]
    public class MemSequence : CompositeGraphNode
    {
        protected override CompositeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index)
        {
            throw new System.NotImplementedException();
        }
    }

    protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
    {
        return new MemSequence() as BehaviourTreeNode<T>;
    }
}