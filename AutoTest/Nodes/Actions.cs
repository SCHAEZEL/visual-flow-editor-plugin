using System.Collections;
using UnityEngine;

namespace XNode.AutoTest
{

    [CreateNodeMenu("Action/ClickBtn")]
    public class ClickBtn : ActionGraphNode
    {
        public override string description => "点击UI控件";
        public string uiName;
        public string ctrlName;
        public int recordTick;
        public string eventType;
        [HideInInspector] public string btnText;

        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("uiName", uiName);
            properties.Add("ctrlName", ctrlName);
            properties.Add("recordTick", recordTick.ToString());
            properties.Add("btnText", btnText);
            properties.Add("eventType", eventType);
            return properties;
        }
    }

    [CreateNodeMenu("Action/UIAction")]
    public class UIAction : ActionGraphNode
    {
    }

    [CreateNodeMenu("Action/Error")]
    public class Error : ActionGraphNode
    {
    }

    [CreateNodeMenu("Action/Failer")]
    public class Failer : ActionGraphNode
    {
    }

    [CreateNodeMenu("Action/Runner")]
    public class Runner : ActionGraphNode
    {
    }

    [CreateNodeMenu("Action/Succeeder")]
    public class Succeeder : ActionGraphNode
    {
    }

    [CreateNodeMenu("Action/Wait")]
    public class Wait : ActionGraphNode
    {
    }
}