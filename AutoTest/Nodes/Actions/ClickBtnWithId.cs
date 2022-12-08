using System;
using System.Collections;

namespace XNode.AutoTest
{
    /// <summary>
    /// 点击配置表注册控件
    /// </summary>
    [Serializable, CreateNodeMenu("Action/点击配置表注册控件")]
    public class ClickBtnWithId : ActionGraphNode
    {
        public override string description => "点击配置表注册控件";
        public string ctrlId;

        public override Hashtable GetProperties()
        {
            Hashtable properties = new Hashtable();
            properties.Add("ctrlId", ctrlId);
            return properties;
        }
    }
}
