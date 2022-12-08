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
    [CreateNodeMenu("Action/执行Lua代码"), NodeWidth(300)]
    public class ExecuteLuaCode : ActionGraphNode
    {
        public override string description => "执行GM命令";
        public List<string> luaCodes;

        ArrayList _luaCodes
        {
            get
            {
                ArrayList array = new ArrayList();
                array.AddRange(luaCodes);
                return array;
            }
        }

        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("gmCodes", luaCodes);
            return properties;
        }
    }
}
