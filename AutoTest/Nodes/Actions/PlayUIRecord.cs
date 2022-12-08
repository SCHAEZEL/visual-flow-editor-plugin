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
    ///  播放UI录像
    /// </summary>
    [NodeWidth(300)]
    [SerializeField, CreateNodeMenu("Action/播放UI录像")]
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
    }
}