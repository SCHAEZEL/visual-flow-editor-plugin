﻿using UnityEngine;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Action/UIAction")]
    public class UIAction : ActionGraphNode
    {
        [Input] public string packageName, uiName, ctrlName;
        [Output] public bool result;
        public ActionType actionType = ActionType.ClickBtn;
        public enum ActionType { ClickBtn, OpenUI, CloseUI }

        // public override object GetValue(XNode.NodePort port)
        // {
        //     vector.x = GetInputValue<float>("x", this.x);
        //     vector.y = GetInputValue<float>("y", this.y);
        //     vector.z = GetInputValue<float>("z", this.z);
        //     return vector;
        // }
        // protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        // {
        //     return new UIAction() as BehaviourTreeNode<T>;
        // }
    }
}