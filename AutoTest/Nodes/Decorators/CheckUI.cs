using System.Collections;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/检查UI状态")]
    public class CheckUI : DecoratorGraphNode
    {
        public override string description => "检查UI状态";
        public string uiName = "";
        public UIStatus condition = UIStatus.Open;
        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("uiName", uiName);
            properties.Add("condition", condition);
            return properties;
        }
    }
}