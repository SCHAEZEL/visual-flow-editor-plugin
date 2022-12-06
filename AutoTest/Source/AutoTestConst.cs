namespace XNode.AutoTest
{
    public static class AutoTestDefine
    {
        public const string WinformTitle = "AutoTestGraph Editor";
        public const string version = "1.0.0";
        public const string ChildPortNameFormat = "child";
        public const string ChildrenPortNameFormat = "children {0}";
    }
    public enum MathType { Add, Subtract, Multiply, Divide }
    public enum NodeType { CompositeNode, ActionNode, DecoratorNode }
}