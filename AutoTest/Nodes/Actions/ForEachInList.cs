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
    /// 遍历列表
    /// </summary>
    [NodeWidth(300)]
    [SerializeField, CreateNodeMenu("Action/遍历列表")]
    public class ForEachInList : ActionGraphNode
    {
        public override string description => "遍历列表";
        public string uiName = "";
        // public string listName = "";
        public string pathFormat = "";

        /// <summary>
        /// 只允许单一自增变量
        /// </summary> 
        public int startIndex = 0;
        // public string btnName = "Button_GO";
        public UIAtion action = UIAtion.Click;

        /// <summary> 
        /// 导出节点属性键值对
        /// </summary>
        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("uiName", uiName);
            properties.Add("action", action);
            // properties.Add("btnName", btnName);
            // properties.Add("listName", listName);
            properties.Add("startIndex", startIndex);

            /// <summary> example: List_LevelPoint:0/Button_GO </summary>
            properties.Add("pathFormat", pathFormat);
            return properties;
        }

        public override object GetValue(NodePort nodePort)
        {
            return null;
        }
    }
}