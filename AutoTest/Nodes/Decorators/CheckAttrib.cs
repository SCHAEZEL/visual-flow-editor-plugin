using UnityEngine;
using System.Collections.Generic;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/CheckAttrib")]
    public class CheckAttrib : DecoratorGraphNode
    {
        [SerializeField] public string desc = "检查角色属性";
        public string attribName = "atk";
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