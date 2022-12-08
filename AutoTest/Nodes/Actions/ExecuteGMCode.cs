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
    [CreateNodeMenu("Action/GM命令"), NodeWidth(300)]
    public class ExecuteGMCode : ActionGraphNode
    {
        public override string description => "执行GM命令";
        public List<string> gmCodes;

        ArrayList _gmCodes
        {
            get
            {
                ArrayList array = new ArrayList();
                array.AddRange(gmCodes);
                return array;
            }
        }

        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("gmCodes", _gmCodes);
            return properties;
        }
    }
}