using UnityEngine;
using System.Collections;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/CheckAttrib")]
    public class CheckAttrib : DecoratorGraphNode
    {
        [SerializeField] public override string description => "检查角色属性";
        public string attribName = "atk";
        public string op = ">";
        public int value = 0;
        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("attribName", attribName);
            properties.Add("op", op);
            properties.Add("value", value.ToString());
            return properties;
        }
    }
}