using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace XNode.AutoTest
{
    [System.Serializable]
    public class BehaviourTreeGraphConnection { }

    public class BehaviourTreeGraphNode : Node
    {
        static int numChildren = 0;
        int globalIndex;
        public string version => AutoTestDefine.version;
        public virtual string description => "Base节点名";
        public virtual string scope => "node";
        public virtual string id => string.Format(AutoTestDefine.DefaultNodeIdFormat, globalIndex);
        public virtual string nodeName => "DefaultNode";
        public virtual NodeType nodeType => NodeType.ActionNode;
        public virtual Hashtable properties => GetProperties();
        public virtual bool isEnableDynamicPort => false;

        const string ChildPortNameFormat = "child";
        const string ChildrenPortNameFormat = "children {0}";

        /// <summary> 
        /// 节点子节点个数，默认为非动态端口(有且仅有一个端口)
        /// </summary>
        public virtual int Size
        {
            get
            {
                var port = GetOutputPort(ChildPortNameFormat);
                var connectedPort = port.Connection as NodePort;
                return connectedPort == null ? 0 : 1;
            }
        }

        /// <summary>
        /// 当节点在编辑器中添加时调用
        /// </summary>
        protected override void Init()
        {
            // title = description;
            numChildren++;
            globalIndex = numChildren;
        }

        /// <summary>
        /// 获取所有子节点
        /// </summary>
        /// <returns></returns>
        public virtual Hashtable GetChildren()
        {
            Hashtable children = new Hashtable();

            for (var i = 0; i < Size; i++)
            {
                BehaviourTreeGraphNode connectedNode;
                var potName = nodeType == NodeType.CompositeNode ? string.Format(ChildrenPortNameFormat, i) : ChildPortNameFormat;
                var port = GetOutputPort(potName);
                if (port == null)
                    continue;
                else
                    connectedNode = port.Connection.node as BehaviourTreeGraphNode;
                children.Add(i + 1, connectedNode.id);
            }
            return children;
        }

        /// <summary>
        /// 获取节点properties，需重写该方法进行定制
        /// </summary>
        /// <returns></returns>
        public virtual Hashtable GetProperties()
        {
            return new Hashtable();
        }

        /// <summary>
        /// 节点位置
        /// </summary>
        /// <returns></returns>
        public virtual Hashtable GetNodePos()
        {
            Hashtable pos = new Hashtable();
            pos.Add("x", this.position.x);
            pos.Add("y", this.position.y);
            return pos;
        }

        /// <summary>
        /// 导出节点基础信息
        /// </summary>
        /// <returns></returns>
        Hashtable ExportNodeBase()
        {
            Hashtable ht = new Hashtable();
            ht.Add("version", version);
            ht.Add("scope", scope);
            ht.Add("id", id);
            ht.Add("properties", GetProperties());
            ht.Add("display", GetNodePos());
            ht.Add("description", description);
            ht.Add("name", name.Replace(" ", "")); // Names from Node contains spaces between words.
            ht.Add("children", GetChildren());
            return ht;
        }

        /// <summary>
        /// 导出完整节点信息，重写该方法以添加额外信息
        /// </summary>
        /// <returns></returns>
        public virtual Hashtable ExportNode()
        {
            return ExportNodeBase();
        }

        /// <summary>
        /// 根据端口名称获取连接的子节点
        /// </summary>
        /// <param name="portName"> 端口名称 </param>
        /// <returns></returns>
        public BehaviourTreeGraphNode GetChild(string portName)
        {
            BehaviourTreeGraphNode node = null;
            NodePort port = GetOutputPort(portName);
            if (port != null)
            {
                var portConnection = port.Connection as NodePort;
                if (portConnection != null)
                {
                    node = portConnection.node as BehaviourTreeGraphNode;
                }
            }
            return node;
        }

        public BehaviourTreeGraphNode GetChild()
        {
            return GetChild(ChildPortNameFormat);
        }

        /// <summary>
        /// 根据索引获取节点连接的子节点
        /// </summary>
        /// <param name="index"> 子节点索引 </param>
        /// <returns></returns>
        public BehaviourTreeGraphNode GetChildAt(int index)
        {
            BehaviourTreeGraphNode node = null;
            string portName = string.Format(ChildrenPortNameFormat, index);
            NodePort port = GetOutputPort(portName);
            if (port != null)
            {
                var portConnection = port.Connection as NodePort;
                if (portConnection != null)
                {
                    node = portConnection.node as BehaviourTreeGraphNode;
                }
            }
            return node;
        }
    }
}