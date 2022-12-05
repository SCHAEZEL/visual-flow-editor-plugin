using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.AutoTest
{
    public abstract class BehaviourTreeGraphNode : Node
    {
        [SerializeField, HideInInspector] bool isRoot;
        [SerializeField] static int numChildren = 0;
        public virtual string nodeName => "DefaultNode";
        public virtual int Size => 1;

        public bool IsRoot
        {
            get => isRoot;
            set => isRoot = value;
        }

        public virtual Dictionary<string, string> GetProperties()
        {
            return new Dictionary<string, string>();
        }

        // [ContextMenu("Set as root")]
        // public void SetAsRoot()
        // {
        //     BehaviourTreeGraph btGraph = graph as BehaviourTreeGraph;
        //     btGraph.SetRoot(this);

        //     NodePort port = GetInputPort("parent");
        //     port.Disconnect(port.Connection);
        // }

        /// <summary>
        /// 导出节点位置的JSON
        /// </summary>
        /// <returns></returns>
        public string GetNodeXYJson()
        {
            Hashtable pos = new Hashtable();
            pos.Add("x", this.position.x);
            pos.Add("y", this.position.y);
            return StringUtil.HashtableToJson(pos);
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }

        public abstract string GetNodeScope();

        // protected override void Init()
        // {
        // numChildren += 1;
        // index = numChildren;
        // }


#if UNITY_EDITOR
        // public BehaviourTreeGraph BuildingGraph { get; set; }

        // void SetNodeIndexInBuildingGraph(int index)
        // {
        //     if (IsRoot == false)
        //     {
        //         var parentNode = GetInputPort("parent").Connection.node as BehaviourTreeGraphNode;
        //         BuildingGraph = parentNode.BuildingGraph;
        //     }

        //     BuildingGraph.SetNodeIndex(GetInstanceID(), index);
        // }
#endif
    }
}