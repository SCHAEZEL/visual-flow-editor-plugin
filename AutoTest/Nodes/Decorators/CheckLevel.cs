using System.Collections;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/检查角色等级")]
    public class CheckLevel : DecoratorGraphNode
    {
        public override string description => "检查角色等级";
        public string op = ">";
        public int value = 0;
        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("op", op);
            properties.Add("value", value);
            return properties;
        }
    }
}