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
    [NodeTint("#685142"), NodeWidth(250)]
    public class TreeRootNode : BehaviourTreeGraphNode
    {
        public string title = "Behavior Demo";

        /// <summary> 用于导出后查看节点备注 </summary>
        public override string description => "树头节点";
        public override string nodeName => "default_node";
        public override string scope => "tree";
        public override string id => string.Format(AutoTestDefine.DefaultTreeIdFormat, treeIndex);
        [SerializeField, Output] BehaviourTreeGraphConnection child;
        static int treeCount = 0;
        int treeIndex;
        protected override void Init()
        {
            treeCount++;
            treeIndex = treeCount;
        }

        /// <summary>
        /// 根节点
        /// </summary>
        /// <value></value>
        public string root
        {
            get
            {
                NodePort childPort = this.GetOutputPort(AutoTestDefine.ChildPortNameFormat);
                BehaviourTreeGraphNode childNode = childPort.node as BehaviourTreeGraphNode;
                return childNode.id;
            }
        }

        /// <summary> Return a Hashtable with all nodes' data insiede. </summary>
        Hashtable GetNodesList()
        {
            Hashtable allNodes = new Hashtable();
            Queue queue = new Queue();
            NodePort childPort = this.GetOutputPort(AutoTestDefine.ChildPortNameFormat);
            queue.Enqueue(childPort.Connection.node);
            while (queue.Count > 0)
            {
                BehaviourTreeGraphNode node = queue.Dequeue() as BehaviourTreeGraphNode;
                if (node == null) continue;

                /// Enqueue all children nodes.
                if (node.Size == -1)
                {
                    EditorUtility.DisplayDialog(AutoTestDefine.WinformTitle,
                        string.Format("缺失子节点，错误内容:\n name:{0}, id:{1}", node.name, node.id), "确认");
                    return allNodes;
                }
                for (var i = 0; i < node.Size; i++)
                {
                    BehaviourTreeGraphNode connectedNode;
                    var potName = node.nodeType == NodeType.CompositeNode ? string.Format(AutoTestDefine.ChildrenPortNameFormat, i) : AutoTestDefine.ChildPortNameFormat;
                    var port = node.GetOutputPort(potName);
                    if (port == null)
                        continue;
                    else
                        connectedNode = port.Connection.node as BehaviourTreeGraphNode;
                    queue.Enqueue(connectedNode);
                }
                allNodes.Add(node.id, node.ExportNode());
            }
            return allNodes;
        }

        /// <summary>
        /// Export behavior tree with JSON format.
        /// </summary>
        [ContextMenu("Export Tree in JSON")]
        public void ExportTreeInJson()
        {
            string dir = Path.Combine(Application.dataPath.Replace("Assets", "UIRecord"));
            string path = EditorUtility.SaveFilePanel("Export Behavior Tree File", dir, id, "json");
            if (path.Length != 0)
            {
                string jsonData = GetJsonData();
                File.WriteAllText(path, jsonData, Encoding.UTF8);
                EditorUtility.DisplayDialog(AutoTestDefine.WinformTitle, string.Format("该行为树已导出LUA格式文件\n路径：{0}", path), "确认");
            }
        }

        /// <summary>
        /// Export behavior tree with LUA wrap.
        /// </summary>
        [ContextMenu("Export Tree in LUA")]
        public void ExportTreeInLua()
        {
            string dir = Path.Combine(Application.dataPath.Replace("Assets", "UIRecord"));
            string path = EditorUtility.SaveFilePanel("Export Behavior Tree File", dir, id, "lua");
            if (path.Length != 0)
            {
                StringBuilder luaData = new StringBuilder("return [[");
                luaData.Append(GetJsonData());
                luaData.Append("]]");
                File.WriteAllText(path, luaData.ToString(), Encoding.UTF8);
                EditorUtility.DisplayDialog(AutoTestDefine.WinformTitle, string.Format("该行为树已导出LUA格式文件\n路径：{0}", path), "确认");
            }
        }

        string GetJsonData()
        {
            Hashtable ht = ExportNode();
            ht.Add("title", title);
            ht.Add("root", root);
            ht.Add("nodes", GetNodesList());
            return StringUtil.HashtableToJson(ht);
        }
    }
}