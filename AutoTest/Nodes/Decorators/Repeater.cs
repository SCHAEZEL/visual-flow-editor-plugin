using System.Collections;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/Repeater")]
    public class Repeater : DecoratorGraphNode
    {
        public int maxLoop = 1;
        public int interval = 10;
        public override string description => "重复执行";
        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("maxLoop", maxLoop);
            properties.Add("interval", interval);
            return properties;
        }
    }
}
