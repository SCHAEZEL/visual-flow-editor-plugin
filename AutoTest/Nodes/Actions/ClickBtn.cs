using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using XNode;

namespace XNode.AutoTest
{
    [CreateNodeMenu("Action/ClickBtn")]
    public class ClickBtn : ActionGraphNode
    {

        public string uiName;
        public string ctrlName;
        public string btnText;

        // protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        // {
        //     return new ClickBtn() as BehaviourTreeNode<T>;
        // }
    }
}