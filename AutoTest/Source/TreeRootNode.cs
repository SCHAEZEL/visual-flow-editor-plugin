using System.Collections;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;
using LuaInterface;

#if UNITY_2019_1_OR_NEWER && USE_ADVANCED_GENERIC_MENU
using GenericMenu = XNodeEditor.AdvancedGenericMenu;
#endif

namespace XNode.AutoTest
{
    [NodeTint("#685142")]
    public class TreeRootNode : BehaviourTreeGraphNode
    {
        const string WinformTitle = "AutoTest Editor";
        static string VERSION = "1.0.0";
        public string title = "A behavior tree";
        public string description = "行为树demo";
        protected string scope { get { return "tree"; } }
        protected string nodeId { get { return "Default_Tree_1"; } }
        [SerializeField, Output]
        BehaviourTreeGraphConnection child;

        /// <summary>
        /// Get tree root data.
        /// </summary>
        /// <value></value>
        public BehaviourTreeGraphConnection rootData
        {
            get { return child; }
        }

        public override string GetNodeScope()
        {
            return scope;
        }

        string GetRootId()
        {
            return "";
        }

        Hashtable GetNodesList()
        {
            Hashtable ht = new Hashtable();
            return ht;
        }

        [ContextMenu("Export Tree")]
        public void ExportTree()
        {
            string dir = Path.Combine(Application.dataPath.Replace("Assets", "UIRecord"));
            string path = EditorUtility.SaveFilePanel("Export Behavior Tree File", dir, "bt_data", "json");
            if (path.Length != 0)
            {
                Hashtable ht = new Hashtable();
                ht.Add("version", VERSION);
                ht.Add("scope", scope);
                ht.Add("id", nodeId);
                ht.Add("title", title);
                ht.Add("description", description);
                ht.Add("root", GetRootId());
                ht.Add("properties", "{}");
                ht.Add("nodes", GetNodesList());
                ht.Add("display", GetNodeXYJson());
                string jsonData = StringUtil.HashtableToJson(ht);
                string result = SaveFile(path, jsonData) ? "行为树导出成功" : "行为树导出失败，路径有误请重试";
                EditorUtility.DisplayDialog(WinformTitle, result, "确认");
            }
        }

        static bool SaveFile(string file, string path)
        {
            using (StreamWriter textWriter = new StreamWriter(file, false, Encoding.UTF8))
            {
                // textWriter.Write(file.ToString());
                // textWriter.Write(sb.ToString());
                // textWriter.Flush();
                // textWriter.Close();

                using (StreamWriter sw = new StreamWriter("CDriveDirs.txt"))
                {
                    // foreach (DirectoryInfo dir in cDirs)
                    // {
                    //     sw.WriteLine(dir.Name);
                    // }
                }
            }
            return true;
        }
    }
}