using System.Collections.Generic;
using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Action/Print")]
    public class Print : ActionGraphNode
    {
        public string text = "";

        public override Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("text", text);
            return properties;
        }
    }
}