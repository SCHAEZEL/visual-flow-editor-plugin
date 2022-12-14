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
    [CreateNodeMenu("Action/Failer")]
    public class Failer : ActionGraphNode
    {
        public override string description => "返回失败";
    }
}
