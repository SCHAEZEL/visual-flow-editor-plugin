using UnityEngine;
using System.Text;
using XNode;

namespace XNode.AutoTest
{
    public static class AutoTestUtil
    {
        public const string seed = "0123456789abcdef";

        public static string CreateNodeUID()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < 32; i++)
            {
                sb.Append(seed[Random.Range(1, 16)]);
            }
            return sb.ToString();
        }
    }
}