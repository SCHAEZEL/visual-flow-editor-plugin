using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace XNode.AutoTest
{
    /// <summary>
    /// Behavior3内置Action
    /// </summary>
    [CreateNodeMenu("Action/返回完成")]
    public class Succeeder : ActionGraphNode
    {
        public override string description => "";
    }
}