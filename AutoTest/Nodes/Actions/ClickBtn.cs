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
    [CreateNodeMenu("Action/ClickBtn")]
    public class ClickBtn : ActionGraphNode
    {
        // [SerializeField, Input] public BehaviourTreeGraphConnection input;
        // [SerializeField, Output] public BehaviourTreeGraphConnection output;

        public string uiName;
        public string ctrlName;
        public string btnText;
        [HideInInspector] public string recordTick;

        public override Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("uiName", uiName);
            properties.Add("ctrlName", uiName);
            properties.Add("btnText", uiName);
            return properties;
        }
    }
}