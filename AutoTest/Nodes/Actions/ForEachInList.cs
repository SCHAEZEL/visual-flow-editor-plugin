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
    [NodeWidth(250)]
    [SerializeField, CreateNodeMenu("Action/遍历列表")]
    public class ForEachInList : ActionGraphNode
    {
        public override string description => "遍历列表";
        public string uiName = "";
        public string listName = "";
        public int startIndex = 0;
        public string btnName = "Button_GO";
        public UIAtion action = UIAtion.Click;

        /// <summary> 
        /// 导出节点属性键值对
        /// </summary>
        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();

            /// <summary> example: WorldMap_HangUp/List_LevelPoint:0/Button_GO </summary>
            string format = string.Format("{0}/{1}:%s/{3}", uiName, listName, startIndex, btnName);
            properties.Add("pathFormat", format);
            properties.Add("startIndex", startIndex);
            return properties;
        }

        public override object GetValue(NodePort nodePort)
        {
            return null;
        }
    }
}