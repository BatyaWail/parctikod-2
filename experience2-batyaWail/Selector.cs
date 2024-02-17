using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experience2_batyaWail
{
    public class Selector
    {
        public string TagName { get; set; }
        public string Id { get; set; }
        public List<string> Classes { get; set; }=new List<string>();
        public Selector Parent { get; set; }
        public Selector Child { get; set; }
        public static Selector SavingQueryString(string query)
        {
            List<string> queryList = query.Split(" ").ToList();
            Selector root = null;
            Selector currentSelector = null;
            foreach (string s in queryList)
            {
                Selector temp = new Selector();
                List<string> list = new List<string>();
                string result = "";

                foreach (char c in s)
                {
                    if (c == '#' || c == '.')
                    {
                        if (result.Length > 0)
                        {
                            list.Add(result);
                            result = "";
                        }
                    }
                    result += c;
                }
                list.Add(result);

                foreach (string st in list)
                {
                    if (st.StartsWith("#"))
                        temp.Id = st.Substring(1);
                    else if (st.StartsWith("."))
                        temp.Classes.Add(st.Substring(1));
                    else if (HtmlHelper.Instance.HtmlTags.Contains(st) || HtmlHelper.Instance.HtmlVoidTags.Contains(st))
                        temp.TagName = st;
                }

                if (currentSelector != null)
                {
                    currentSelector.Child = temp;
                    temp.Parent = currentSelector;
                }
                else
                {
                    root = temp;
                }

                currentSelector = temp;
            }
            return root;
        }

    }
}
       

 

