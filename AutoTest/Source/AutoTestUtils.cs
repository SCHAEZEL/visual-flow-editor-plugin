using System.Collections;

namespace xNode.AutoTest
{
    public class AutoTestUtils
    {
        /// <summary>
        /// 导出Json格式
        /// </summary>
        /// <param name="hr"></param>
        /// <param name="readcount"></param>
        /// <returns></returns>
        public static string HashtableToJson(Hashtable hr, int readcount = 0)
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
                            json += key + HashtableToJson(t, readcount++) + ",";
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
            foreach (Hashtable each in array)
            {
                json += HashtableToJson(each) + ",";
            }

            json = json + "],";
            return json;
        }
    }
}