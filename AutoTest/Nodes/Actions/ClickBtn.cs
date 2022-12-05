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
        public string uiName;
        public string ctrlName;
        public int recordTick;
        public string eventType;
        [HideInInspector] public string btnText;

        public override Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("uiName", uiName);
            properties.Add("ctrlName", uiName);
            properties.Add("recordTick", uiName.ToString());
            properties.Add("btnText", uiName);
            properties.Add("btnText", eventType);
            return properties;
        }
    }
}