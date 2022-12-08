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

    /// <summary>
    /// 打印字符串
    /// </summary>
    [CreateNodeMenu("Action/打印")]
    public class Print : ActionGraphNode
    {
        public override string description => "执行Lua代码";
        public string text = "";
        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("text", text);
            return properties;
        }
    }
}