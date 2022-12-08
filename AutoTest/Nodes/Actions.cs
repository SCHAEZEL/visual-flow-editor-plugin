using System.Collections;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace XNode.AutoTest
{
    /// <summary>
    /// 点击按钮
    /// </summary>
    [CreateNodeMenu("Action/ClickBtn")]
    public class ClickBtn : ActionGraphNode
    {
        public override string description => "点击UI控件";
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
    [CreateNodeMenu("Action/PlayUIRecord")]
    public class PlayUIRecord : ActionGraphNode
    {
        public string recordFileName = "";
        public override string description => "播放UI录像";
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
            string path = EditorUtility.SaveFilePanel("Export UI Record", dir, "record_file", "json");
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
            jsonData.Add("opers", operArray); // TODO 需支持Object导出json
            string jsonContent = StringUtil.HashtableToJson(jsonData);
            if (string.IsNullOrEmpty(jsonContent))
            {
                EditorUtility.DisplayDialog(AutoTestDefine.WinformTitle, string.Format("UI录像数据为空，无法导出"), "确认");
                return;
            }
            File.WriteAllText(path, jsonContent, Encoding.UTF8);
            EditorUtility.DisplayDialog(AutoTestDefine.WinformTitle, string.Format("已导出UI录制文件文件路径：\n{0}", path), "确认");
        }
    }


    /// <summary>
    /// 打印字符串
    /// </summary>
    [CreateNodeMenu("Action/Print")]
    public class Print : ActionGraphNode
    {
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
    [CreateNodeMenu("Action/Error")]
    public class Error : ActionGraphNode
    {
    }


    /// <summary>
    /// Behavior3内置Action
    /// </summary>
    [CreateNodeMenu("Action/Failer")]
    public class Failer : ActionGraphNode
    {
    }


    /// <summary>
    /// Behavior3内置Action
    /// </summary>
    [CreateNodeMenu("Action/Runner")]
    public class Runner : ActionGraphNode
    {
    }


    /// <summary>
    /// Behavior3内置Action
    /// </summary>
    [CreateNodeMenu("Action/Succeeder")]
    public class Succeeder : ActionGraphNode
    {
    }


    /// <summary>
    /// Behavior3内置Action
    /// </summary>
    [CreateNodeMenu("Action/Wait")]
    public class Wait : ActionGraphNode
    {
    }
}