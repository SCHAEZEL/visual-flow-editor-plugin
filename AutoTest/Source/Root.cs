// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using System.Reflection;
// using UnityEngine;
// using UnityEngine.Events;
// using XNode;

// namespace XNode.AutoTest
// {
//     [NodeTint("#685142")]
//     public class Root : BehaviourTreeGraphNode
//     {
//         static string version = "1.0.0";

//         [SerializeField] public new string nodeName = "Tree Head";
//         [HideInInspector] public string scope = "tree";
//         [SerializeField, Output] BehaviourTreeGraphConnection child;

//         /// <summary>
//         /// Get tree root data.
//         /// </summary>
//         /// <value></value>
//         public BehaviourTreeGraphConnection rootData
//         {
//             get { return child; }
//         }

//         public override string GetNodeScope()
//         {
//             return scope;
//         }
//     }
// }