using System.Collections;
using UnityEngine;

namespace XNode.AutoTest
{
    /// <summary>
    /// 清空黑板数据
    /// </summary>
    [SerializeField, CreateNodeMenu("Action/ClearBlackboard")]
    public class ClearBlackboard : ActionGraphNode
    {
        public override string description => "清空黑板数据";
    }
}