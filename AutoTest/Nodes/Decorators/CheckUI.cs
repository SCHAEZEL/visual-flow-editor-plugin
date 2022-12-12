using System.Collections;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Decorators/检查UI状态")]
    public class CheckUI : DecoratorGraphNode
    {
        public override string description => "检查UI状态";
        public string uiName = "";
        public UIStatus checkStatus = UIStatus.Open;
        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("uiName", uiName);
            properties.Add("isOpen", checkStatus);
            return properties;
        }
    }
}