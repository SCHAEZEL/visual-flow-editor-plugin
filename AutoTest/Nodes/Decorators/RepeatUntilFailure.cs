using System.Collections;

namespace XNode.AutoTest
{

    [CreateNodeMenu("Decorators/RepeatUntilFailure")]
    public class RepeatUntilFailure : DecoratorGraphNode
    {
        public override string description => "运行直至返回失败";
    }
}
