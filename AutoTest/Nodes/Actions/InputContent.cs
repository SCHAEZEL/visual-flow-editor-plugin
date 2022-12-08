using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Action/控件填入内容")]
    public class InputContent : ActionGraphNode
    {
        public override string description => "控件填入内容";
        public string packageName;
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
            properties.Add("packageName", packageName);
            return properties;
        }
    }
}