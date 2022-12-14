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
    [CreateNodeMenu("Action/控件填入内容"), NodeWidth(350)]
    public class TextInput : ActionGraphNode
    {
        public override string description => "控件填入内容";
        public string uiName;
        public string ctrlName;
        public string text;

        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("uiName", uiName);
            properties.Add("ctrlName", ctrlName);
            properties.Add("text", text);
            return properties;
        }
    }
}