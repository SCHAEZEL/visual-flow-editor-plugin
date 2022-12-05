using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.AutoTest
{
    [Serializable]
    public class BaseEmptyNode { }

    [Serializable]
    public class BaseNode : BehaviourTreeGraphNode
    {
        [SerializeField, Input] public BehaviourTreeGraphConnection parent;
        [SerializeField, Output] public BehaviourTreeGraphConnection child;
    }
}
