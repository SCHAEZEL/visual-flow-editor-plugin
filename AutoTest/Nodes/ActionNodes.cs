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
    /// 点击按钮
    /// </summary>
    [CreateNodeMenu("Action/点击按钮")]
    public class ClickBtn : ActionGraphNode
    {
        public override string description => "点击按钮";
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


    /// <summary>
    /// 点击配置表注册控件
    /// </summary>
    [CreateNodeMenu("Action/点击配置表注册控件")]
    public class ClickBtnWithId : ActionGraphNode
    {
        public override string description => "点击配置表注册控件";
        public string ctrlId;

        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("ctrlId", ctrlId);
            return properties;
        }
    }


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


    /// <summary>
    ///  播放UI录像
    /// </summary>
    [NodeWidth(300)]
    [CreateNodeMenu("Action/播放UI录像")]
    public class PlayUIRecord : ActionGraphNode
    {
        public override string description => "播放UI录像";
        public string recordFileName = "";
        public string fileSuffix = "json";
        [SerializeField, Output] BehaviourTreeGraphConnection startNode;

        /// <summary> 
        /// 导出节点属性键值对
        /// </summary>
        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("recordFileName", recordFileName);
            return properties;
        }

        /// <summary>
        /// 导出UI录像的Json文件
        /// </summary>
        [ContextMenu("Export UIRecord's Json")]
        public void ExportUIRecord()
        {
            string dir = Path.Combine(Application.dataPath.Replace("Assets", "UIRecord"));
            string path = EditorUtility.SaveFilePanel("Export UI Record", dir, recordFileName, "json");
            if (path.Length == 0) return;

            Hashtable jsonData = new Hashtable();
            ArrayList operArray = new ArrayList();
            ClickBtn node = GetChild("startNode") as ClickBtn;
            while (node != null)
            {
                Hashtable oper = node.GetProperties();
                operArray.Add(oper);
                node = node.GetChild() as ClickBtn;
            }
            jsonData.Add("recordTick", Time.time); // TODO
            jsonData.Add("fileName", path);
            jsonData.Add("opers", operArray);
            string jsonContent = AutoTestUtils.ToJson(jsonData);
            if (string.IsNullOrEmpty(jsonContent))
            {
                AutoTestUtils.Confirm(string.Format("UI录像数据为空，无法导出"));
                return;
            }
            File.WriteAllText(path, jsonContent, Encoding.UTF8);
            AutoTestUtils.Confirm(string.Format("已导出UI录制文件文件路径：\n{0}", path));
        }

        [ContextMenu("Reveal In File Explorer")]
        public void RevealInFileExplorer(string path)
        {

        }


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


        /// <summary>
        /// Behavior3内置Action
        /// </summary>
        [CreateNodeMenu("Action/随机击杀怪物")]
        public class KillMonster : ActionGraphNode
        {
            public override string description => "随机击杀怪物";

            /// <summary> 击杀数量 </summary>
            public int number = 1; ///
            public override Hashtable GetProperties()
            {
                Hashtable properties = new Hashtable();
                properties.Add("number", number);
                return properties;
            }
        }


        /// <summary>
        /// Behavior3内置Action
        /// </summary>
        [CreateNodeMenu("Action/Error")]
        public class Error : ActionGraphNode
        {
            public override string description => "";
        }


        /// <summary>
        /// Behavior3内置Action
        /// </summary>
        [CreateNodeMenu("Action/Failer")]
        public class Failer : ActionGraphNode
        {
            public override string description => "";
        }


        /// <summary>
        /// Behavior3内置Action
        /// </summary>
        [CreateNodeMenu("Action/Runner")]
        public class Runner : ActionGraphNode
        {
            public override string description => "";
        }


        /// <summary>
        /// Behavior3内置Action
        /// </summary>
        [CreateNodeMenu("Action/Succeeder")]
        public class Succeeder : ActionGraphNode
        {
            public override string description => "";
        }


        /// <summary>
        /// Behavior3内置Action
        /// </summary>
        [CreateNodeMenu("Action/Wait")]
        public class Wait : ActionGraphNode
        {
            public override string description => "";
        }
    }
}