using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace XNode.AutoTest
{
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

        /// <summary> Count of children nodes. </summary>
        public virtual int Size
        {
            get
            {
                var port = GetOutputPort(AutoTestDefine.ChildPortNameFormat);
                var connectedPort = port.Connection as NodePort;
                return connectedPort == null ? 0 : 1;
            }
        }

        protected override void Init()
        {
            // title = description;
            numChildren++;
            globalIndex = numChildren;
        }

        // public virtual string GetChildren()
        // {
        //     StringBuilder children = new StringBuilder("[");

        //     for (var i = 0; i < Size; i++)
        //     {
        //         BehaviourTreeGraphNode connectedNode;
        //         var potName = nodeType == NodeType.CompositeNode ? string.Format(AutoTestDefine.ChildrenPortNameFormat, i) : AutoTestDefine.ChildPortNameFormat;
        //         var port = GetOutputPort(potName);
        //         if (port == null)
        //             continue;
        //         else
        //             connectedNode = port.Connection.node as BehaviourTreeGraphNode;
        //         children.AppendLine(string.Format("'{0}',", id));
        //     }
        //     return children.ToString();
        // }

        public virtual Hashtable GetChildren()
        {
            Hashtable children = new Hashtable();

            for (var i = 0; i < Size; i++)
            {
                BehaviourTreeGraphNode connectedNode;
                var potName = nodeType == NodeType.CompositeNode ? string.Format(AutoTestDefine.ChildrenPortNameFormat, i) : AutoTestDefine.ChildPortNameFormat;
                var port = GetOutputPort(potName);
                if (port == null)
                    continue;
                else
                    connectedNode = port.Connection.node as BehaviourTreeGraphNode;
                children.Add(i + 1, connectedNode.id);
            }
            return children;
        }

        public virtual Hashtable GetProperties()
        {
            return new Hashtable();
        }

        public virtual Hashtable GetNodePos()
        {
            Hashtable pos = new Hashtable();
            pos.Add("x", this.position.x);
            pos.Add("y", this.position.y);
            return pos;
        }
        public override object GetValue(NodePort port)
        {
            return null;
        }

        public virtual Hashtable ExportNodeBase()
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

        public virtual Hashtable ExportNode()
        {
            return ExportNodeBase();
        }
    }
}