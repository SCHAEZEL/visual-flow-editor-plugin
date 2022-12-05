using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/CheckLevel")]
    public class CheckLevel : DecoratorGraphNode
    {
        [SerializeField] public string desc = "检查角色等级";
        public string op = ">";
        public int value = 0;
        public override Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("attribName", attribName);
            properties.Add("op", op);
            properties.Add("value", value.ToString());
            return properties;
        }
    }
}