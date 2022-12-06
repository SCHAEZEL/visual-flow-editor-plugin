using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace XNode.AutoTest
{
    [CreateAssetMenu(fileName = "New BehaviourTree Graph", menuName = "xNode Examples/BehaviourTree Graph")]

    public class BehaviourTreeGraph : NodeGraph
    {
        // public void SetRoot(BehaviourTreeGraphNode node)
        // {
        //     if (root) { root.IsRoot = false; }
        //     root = node;
        //     root.IsRoot = true;
        // }

        public override Node AddNode(Type type)
        {
            // Only allow the right type of nodes.
            if (typeof(BehaviourTreeGraphNode).IsAssignableFrom(type) == false)
            {
                return null;
            }
            // Set first node as root by default
            var node = base.AddNode(type) as BehaviourTreeGraphNode;
            // if (root == null)
            // {
            //     SetRoot(node);
            // }

            return node;
        }

        public BehaviourTreeGraphNode Root => root;

        #region Private
        [SerializeField] BehaviourTreeGraphNode root;
        #endregion

#if UNITY_EDITOR
        #region Editor
        Dictionary<int, int> nodeIdToIndexMap = new Dictionary<int, int>();

        public void SetNodeIndex(int nodeId, int index)
        {
            nodeIdToIndexMap[nodeId] = index;
        }

        public bool TryGetNodeIndex(int nodeId, out int index)
        {
            return nodeIdToIndexMap.TryGetValue(nodeId, out index);
        }
        #endregion
#endif
    }
}