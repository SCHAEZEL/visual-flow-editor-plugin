using System.Collections;
using UnityEngine;

namespace XNode.AutoTest
{
    /// <summary>
    /// 随机击杀怪物
    /// </summary>
    [CreateNodeMenu("Action/随机击杀怪物")]
    public class KillMonster : ActionGraphNode
    {
        public override string description => "随机击杀怪物";

        /// <summary> 击杀数量 </summary>
        public int number = 1; ///
        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("number", number);
            return properties;
        }
    }
}