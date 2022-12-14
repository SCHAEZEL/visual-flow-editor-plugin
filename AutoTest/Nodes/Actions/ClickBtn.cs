using System.Collections;
using UnityEngine;

namespace XNode.AutoTest
{
    /// <summary>
    /// 点击按钮
    /// </summary>
    [SerializeField, CreateNodeMenu("Action/点击按钮")]
    public class ClickBtn : ActionGraphNode
    {
        public override string description => "点击按钮";
        [HideInInspector] public string packageName;
        public string uiName;
        public string ctrlName;
        public string btnText;
        [HideInInspector] public int recordTick;
        [HideInInspector] public string eventType = "onClick";

        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("uiName", uiName);
            properties.Add("ctrlName", ctrlName);
            properties.Add("recordTick", recordTick.ToString());
            properties.Add("btnText", btnText);
            properties.Add("eventType", eventType);
            properties.Add("packageName", packageName);
            return properties;
        }
    }
}