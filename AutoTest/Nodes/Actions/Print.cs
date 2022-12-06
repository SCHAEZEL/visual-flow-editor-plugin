using System.Collections;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Action/Print")]
    public class Print : ActionGraphNode
    {
        public string text = "";

        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("text", text);
            return properties;
        }
    }
}