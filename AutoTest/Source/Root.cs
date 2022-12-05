using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using XNode;

namespace XNode.AutoTest
{
    [NodeTint("#685142")]
    public class Root : BehaviourTreeGraphNode
    {
        public string treeName;
        [SerializeField, Output] BehaviourTreeGraphConnection child;
        [HideInInspector] string scope;
        public BehaviourTreeGraphConnection root
        {
            get { return child; }
        }
    }
}