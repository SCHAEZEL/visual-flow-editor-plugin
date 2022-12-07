namespace XNode.AutoTest
{
    public static class AutoTestDefine
    {
        public const string version = "1.0.0";
        public const string WinformTitle = "AutoTestGraph Editor";
        public const string ChildPortNameFormat = "child";
        public const string ChildrenPortNameFormat = "children {0}";
        public const string DefaultTreeIdFormat = "default_tree_{0}";
        public const string DefaultNodeIdFormat = "default_node_id_{0}";

    }
    public enum MathType { Add, Subtract, Multiply, Divide }
    public enum NodeType { CompositeNode, ActionNode, DecoratorNode }
    public enum ChainType { Begin, Running, End };
}