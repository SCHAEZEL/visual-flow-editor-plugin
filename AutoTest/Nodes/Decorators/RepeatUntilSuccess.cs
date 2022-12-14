using System.Collections;

namespace XNode.AutoTest
{

    [CreateNodeMenu("Decorators/RepeatUntilSuccess")]
    public class RepeatUntilSuccess : DecoratorGraphNode
    {
        public override string description => "运行直至成功";

        public int maxLoop = 1;
        public NeedLog needLog = NeedLog.True;

        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("maxLoop", maxLoop);
            properties.Add("needLog", needLog);
            return properties;
        }
    }
}
