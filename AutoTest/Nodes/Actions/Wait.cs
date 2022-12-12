using System.Collections;

namespace XNode.AutoTest
{
    /// <summary>
    /// Behavior3内置Action
    /// </summary>
    [CreateNodeMenu("Action/Wait")]
    public class Wait : ActionGraphNode
    {
        public override string description => "等待";
        public float interval = 5.0f;
        public override Hashtable GetProperties()
        {
            Hashtable ht = new Hashtable();
            ht.Add("interval", interval);
            return ht;
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}