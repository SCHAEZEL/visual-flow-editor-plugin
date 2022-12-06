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

        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("uiName", uiName);
            properties.Add("ctrlName", ctrlName);
            properties.Add("recordTick", recordTick.ToString());
            properties.Add("btnText", btnText);
            properties.Add("eventType", eventType);
            return properties;
        }
    }
}