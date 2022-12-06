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
        public override string description => "随便一棵树";
        public override string nodeName => "DefaultNode";
        public override string scope => "tree";
        public override string id => "default_tree_id";
        static int treeCount = 0;
        public string root
        {
            get
            {
                NodePort childPort = this.GetOutputPort("child");
                BehaviourTreeGraphNode childNode = childPort.node as BehaviourTreeGraphNode;
                return childNode.id;
            }
        }
        [SerializeField, Output] BehaviourTreeGraphConnection child;

        /// <summary> Return a Hashtable with all nodes' data insiede. </summary>
        Hashtable GetNodesList()
        {
            Hashtable allNodes = new Hashtable();
            Queue queue = new Queue();
            NodePort childPort = this.GetOutputPort("child");
            queue.Enqueue(childPort.Connection.node);
            while (queue.Count > 0)
            {
                BehaviourTreeGraphNode node = queue.Dequeue() as BehaviourTreeGraphNode;
                if (node == null) continue;

                /// Enqueue all child nodes.
                if (node.Size == -1)
                {
                    EditorUtility.DisplayDialog(AutoTestDefine.WinformTitle,
                        string.Format("缺失子节点，错误内容:\n name:{0}, id:{1}", node.name, node.id), "确认");
                    return allNodes;
                }
                for (var i = 0; i < node.Size; i++)
                {
                    BehaviourTreeGraphNode connectedNode;
                    var potName = node.nodeType == NodeType.CompositeNode ? string.Format(AutoTestDefine.ChildrenPortNameFormat, i) : "child";
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
        [ContextMenu("Export Tree")]
        public void ExportTree()
        {
            string dir = Path.Combine(Application.dataPath.Replace("Assets", "UIRecord"));
            string path = EditorUtility.SaveFilePanel("Export Behavior Tree File", dir, title, "json");
            if (path.Length != 0)
            {
                Hashtable ht = ExportNode();
                ht.Add("title", title);
                ht.Add("root", root);
                ht.Add("nodes", GetNodesList());
                string jsonData = StringUtil.HashtableToJson(ht);
                File.WriteAllText(path, jsonData, Encoding.UTF8);
                EditorUtility.DisplayDialog(AutoTestDefine.WinformTitle, string.Format("行为树导出成功，路径：\n{0}", path), "确认");
            }
        }
    }
}