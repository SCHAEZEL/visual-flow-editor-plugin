using System.Collections;
using UnityEditor;

namespace XNode.AutoTest
{
    public static class AutoTestUtils
    {
        /// <summary>
        /// 将Hashtable导出Json格式
        /// </summary>
        /// <param name="hr"></param>
        /// <param name="readcount"></param>
        /// <returns></returns>
        public static string ToJson(Hashtable hr, int readcount = 0)
        {
            string json = "{";
            foreach (DictionaryEntry row in hr)
            {
                try
                {
                    string key = "\"" + row.Key + "\":";
                    if (row.Value is Hashtable)
                    {
                        Hashtable t = (Hashtable)row.Value;
                        if (t.Count > 0)
                        {
                            json += key + ToJson(t, readcount++) + ",";
                        }
                        else { json += key + "{},"; }
                    }
                    else if (row.Value is ArrayList)
                    {
                        json += key + ArrayListToJson(row.Value as ArrayList);
                    }
                    else
                    {
                        string value = "\"" + row.Value.ToString() + "\",";
                        json += key + value;
                    }
                }
                catch { }

            }

            json = json + "}";
            return json;
        }

        public static string ArrayListToJson(ArrayList array)
        {
            string json = "[";
            foreach (var each in array)
            {
                if (each is Hashtable)
                    json += ToJson(each as Hashtable);
                else if (each is string)
                    json += "\"" + each as string + "\"";
                json += ",";
            }

            json = json + "],";
            return json;
        }

        public static bool Confirm(string message, string ok = "确认", string cancel = null)
        {
            if (EditorUtility.DisplayDialog(AutoTestDefine.WinformTitle, message, ok, cancel))
                return true;
            else
                return false;
        }

        public static void OpenFileWithExplorer(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe", path.Replace("/", "\\"));
        }
    }
}