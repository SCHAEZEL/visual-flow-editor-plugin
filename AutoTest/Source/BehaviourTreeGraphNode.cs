using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.AutoTest
{
    public class BehaviourTreeGraphNode : Node
    {
        static int numChildren = 0;
        int globalIndex;
        public string version => AutoTestDefine.version;
        public virtual string description => "通用描述";
        public virtual string scope => "node";
        public virtual string id => string.Format("default_node_id_{0}", globalIndex);
        public virtual string nodeName => "DefaultNode";
        public virtual NodeType nodeType => NodeType.ActionNode;

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
            numChildren++;
            globalIndex = numChildren;
        }

        public virtual Hashtable properties => GetProperties();

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
            return ht;
        }

        public virtual Hashtable ExportNode()
        {
            return ExportNodeBase();
        }
    }
}