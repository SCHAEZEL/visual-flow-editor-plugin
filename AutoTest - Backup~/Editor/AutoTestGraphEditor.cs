using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XNodeEditor;
using XUPorterJSON;
#if UNITY_2019_1_OR_NEWER && USE_ADVANCED_GENERIC_MENU
using GenericMenu = XNodeEditor.AdvancedGenericMenu;
#endif

namespace XNode.AutoTest
{
    [CustomNodeGraphEditor(typeof(AutoTestGraph))]
    public class AutoTestGraphEditor : NodeGraphEditor
    {

        /// <summary>
        /// Overriding GetNodeMenuName lets you control if and how nodes are categorized.
        /// In this example we are sorting out all node types that are not in the XNode.Examples namespace.
        /// </summary>
        public override string GetNodeMenuName(System.Type type)
        {
            if (type.Namespace == "XNode.AutoTest")
            {
                return base.GetNodeMenuName(type).Replace("X Node/Auto Test/", "");
            }
            else return null;
        }

        public override void AddContextMenuItems(GenericMenu menu, Type compatibleType = null, XNode.NodePort.IO direction = XNode.NodePort.IO.Input)
        {
            base.AddContextMenuItems(menu, compatibleType, direction);
            menu.AddItem(new GUIContent("Import UI Record File"), false, ImportUIRecordFile, this);
            menu.AddItem(new GUIContent("Export BT File"), false, ExportBTFile, this);
        }
        /// <summary>
        /// Import UI record file by UIRecordMgr over JSON format.
        /// </summary>
        /// <param name="userData"></param>
        static void ImportUIRecordFile(object userData)
        {
            NodeGraphEditor editor = userData as NodeGraphEditor;
            string dir = Path.Combine(Application.dataPath.Replace("Assets", "UIRecord"));
            string path = EditorUtility.OpenFilePanel("Import UI Record File", dir, "json");
            if (path.Length != 0)
            {
                var fileContent = File.ReadAllText(path);
                var data = (Hashtable)XUPorterJSON.MiniJSON.jsonDecode(fileContent);
                var i = 0;
                var perNumInLine = 15;
                var nodeSize = 300;
                Node lastNode = null;
                foreach (Hashtable m in data["opers"] as ArrayList)
                {
                    var pos = new Vector2((i % perNumInLine) * nodeSize, (i / perNumInLine) * nodeSize);
                    i++;

                    var node = editor.CreateNode(typeof(ClickBtn), pos) as ClickBtn;
                    node.uiName = m["uiName"] as string;
                    node.ctrlName = m["ctrlName"] as string;

                    if (lastNode != null)
                    {
                        NodePort outputPort = lastNode.GetOutputPort("output");
                        NodePort inputPort = node.GetInputPort("input");
                        outputPort.Connect(inputPort);
                    }
                    lastNode = node;
                    Debug.LogWarning(m.ToString());
                }
            }
        }

        /// <summary>
        /// Export behavior tree with JSON format.
        /// </summary>
        /// <param name="userData"></param>
        static void ExportBTFile(object userData)
        {
            NodeGraphEditor editor = userData as NodeGraphEditor;
            string dir = Path.Combine(Application.dataPath.Replace("Assets", "UIRecord"));
            string path = EditorUtility.OpenFilePanel("Import UI Record File", dir, "json");
            if (path.Length != 0)
            {
                var fileContent = File.ReadAllText(path);
                var data = (Hashtable)XUPorterJSON.MiniJSON.jsonDecode(fileContent);
                var i = 0;
                var perNumInLine = 15;
                var nodeSize = 300;
                Node lastNode = null;
                foreach (Hashtable m in data["opers"] as ArrayList)
                {
                    var pos = new Vector2((i % perNumInLine) * nodeSize, (i / perNumInLine) * nodeSize);
                    i++;

                    var node = editor.CreateNode(typeof(ClickBtn), pos) as ClickBtn;
                    node.uiName = m["uiName"] as string;
                    node.ctrlName = m["ctrlName"] as string;

                    if (lastNode != null)
                    {
                        NodePort outputPort = lastNode.GetOutputPort("output");
                        NodePort inputPort = node.GetInputPort("input");
                        outputPort.Connect(inputPort);
                    }
                    lastNode = node;
                    Debug.LogWarning(m.ToString());
                }
            }
        }
    }
}