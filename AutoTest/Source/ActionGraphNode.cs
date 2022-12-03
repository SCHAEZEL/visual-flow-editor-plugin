using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.AutoTest
{
    [NodeTint("#2e4e6b")]
    public abstract class ActionGraphNode : BehaviourTreeGraphNode
    {
        #region Public
        public override int Size
        {
            get
            {
                var size = 0;
                for (var i = 0; i < childrenCount; i++)
                {
                    var port = GetOutputPort(string.Format(ChildrenPortNameFormat, i));
                    var connectedNode = port.Connection.node as BehaviourTreeGraphNode;
                    if (connectedNode == null) continue;
                    size += connectedNode.Size;
                }

                return size + 1;
            }
        }
        #endregion

        #region Protected

        protected override void Init()
        {
            base.Init();
            // Calculate children count.
            // note: it appears that xNode doesn't populate the children list on init.
            // Which results in children.Count being 0.
            childrenCount = 0;
            while (true)
            {
                var port = GetOutputPort(string.Format(ChildrenPortNameFormat, childrenCount));
                if (port == null) break;
                childrenCount++;
            }
        }

        #endregion

        #region Private
        int childrenCount;

        const string ChildrenPortNameFormat = "children {0}";
        #endregion
    }
}