using System.Collections;
using UnityEngine;

namespace XNode.AutoTest
{

    [CreateNodeMenu("Decorators/CheckLevel")]
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

    [CreateNodeMenu("Decorators/Inverter")]
    public class Inverter : DecoratorGraphNode
    {
    }

    [CreateNodeMenu("Decorators/Limiter")]
    public class Limiter : DecoratorGraphNode
    {
    }

    [CreateNodeMenu("Decorators/MaxTime")]
    public class MaxTime : DecoratorGraphNode
    {
    }

    [CreateNodeMenu("Decorators/Repeater")]
    public class Repeater : DecoratorGraphNode
    {
    }

    [CreateNodeMenu("Decorators/RepeatUntilFailure")]
    public class RepeatUntilFailure : DecoratorGraphNode
    {
    }

    [CreateNodeMenu("Decorators/RepeatUntilSuccess")]
    public class RepeatUntilSuccess : DecoratorGraphNode
    {
    }
}