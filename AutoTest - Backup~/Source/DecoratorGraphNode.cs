using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.AutoTest
{
    [NodeTint("#6b2e53")]
    public abstract class DecoratorGraphNode : BehaviourTreeGraphNode
    {
        #region Public
        public override int Size
        {
            get
            {
                var port = GetOutputPort(string.Format(ChildPortNameFormat));
                var connectedNode = port.Connection.node as BehaviourTreeGraphNode;
                return connectedNode == null ? 1 : connectedNode.Size + 1;
            }
        }
        #endregion

        #region Private
        const string ChildPortNameFormat = "child";
        #endregion
    }
}