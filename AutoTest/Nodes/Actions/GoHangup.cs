using System.Collections;

namespace XNode.AutoTest
{
    /// <summary>
    /// 数据记录相关节点
    /// </summary>
    [CreateNodeMenu("Action/前往下一个挂机点")]
    public class GoHangup : ActionGraphNode
    {
        /// <summary> 节点停留时间 </summary>
        public int duration = 40;

        public override string description => "前往下一个挂机点";
        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("duration", duration);
            return properties;
        }
    }
}