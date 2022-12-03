﻿using UnityEngine;

namespace XNode.AutoTest
{

    [CreateNodeMenu("Action/Error")]
    public class Error : ActionGraphNode
    {
        [Input] public float x, y, z;
        [Output] public Vector3 vector;

        public override object GetValue(XNode.NodePort port)
        {
            vector.x = GetInputValue<float>("x", this.x);
            vector.y = GetInputValue<float>("y", this.y);
            vector.z = GetInputValue<float>("z", this.z);
            return vector;
        }

        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            return new Error() as BehaviourTreeNode<T>;
        }
    }
}