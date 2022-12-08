namespace XNode.AutoTest
{
    /// <summary>
    /// 数据记录相关节点
    /// </summary>
    [CreateNodeMenu("Action/数据操作")]
    public class DataAction : ActionGraphNode
    {
        public ActionType action = ActionType.Begin;
        public override string description => "数据操作";
    }
}