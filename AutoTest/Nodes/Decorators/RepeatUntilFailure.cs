using System.Collections;

namespace XNode.AutoTest
{

    [CreateNodeMenu("Decorators/RepeatUntilFailure")]
    public class RepeatUntilFailure : DecoratorGraphNode
    {
        public override string description => "运行直至返回失败";
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
