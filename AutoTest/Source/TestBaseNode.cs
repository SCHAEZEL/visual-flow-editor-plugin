using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.AutoTest
{
    [NodeTint("#930000")]
    public abstract class TestBaseNode : BehaviourTreeGraphNode
    {
        #region Public
        public override int Size
        {
            // get
            // {
            //     var size = 0;
            //     for (var i = 0; i < childrenCount; i++)
            //     {
            //         var port = GetOutputPort(string.Format(ChildrenPortNameFormat, i));
            //         var connectedNode = port.Connection.node as BehaviourTreeGraphNode;
            //         if (connectedNode == null) continue;
            //         size += connectedNode.Size;
            //     }

            //     return size + 1;
            // }
            get
            {
                return 1;
            }
        }
        #endregion

        #region Private
        [SerializeField, Output(dynamicPortList = true)] List<BehaviourTreeGraphNode> children;
        int childrenCount;

        const string ChildrenPortNameFormat = "children {0}";
        #endregion
    }
}