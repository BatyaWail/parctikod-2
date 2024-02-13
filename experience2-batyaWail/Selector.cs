using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experience2_batyaWail
{
    public class Selector
    {
        /*
          TagName
          Id
          Classes (רשימה)
         */
        public string TagName { get; set; }
        public string Id { get; set; }
        public List<string> Classes { get; set; }=new List<string>();
        public Selector Parent { get; set; }
        public Selector Child { get; set; }


        public static Selector SavingQueryString(string query)
        {
            List<string> queryList = query.Split(" ").ToList();
            Selector root=new Selector();
            Selector currentSelector = new Selector();
            string result = "";
            bool isFirst = true;
            foreach (string s in queryList)
            {
                Selector temp = new Selector();
                List<string> list = new List<string>();

                foreach (char c in s)
                {
                    //"div#mydiv .class-name”

                    if (c == '#' || c == '.')
                    {
                        if (result.Length > 0)
                        {
                            list.Add(result);
                            result = "";
                        }
                    }
                    result += c;
                    Console.WriteLine();
                }
                list.Add(result);
                foreach (string st in list)
                {
                    if (st.StartsWith("#"))
                        temp.Id = st.Substring(1);
                    else if (st.StartsWith("."))
                        temp.Classes.Add(st.Substring(1));
                    else if (HtmlHelper.Instance.htmlTags.Contains(st) || HtmlHelper.Instance.htmlVoidTags.Contains(st))
                        temp.TagName = st;

                }

                currentSelector.Child = temp;
                temp.Parent=currentSelector;
                if (isFirst)
                {
                    root = temp;
                    //root = new Selector(temp);
                    //root.Id = temp.Id;
                    //root.Parent = temp.Parent;
                    //root.Child=temp.Child;
                    //root.Classes=temp.Classes;  
                    //root.TagName=temp.TagName;
                    isFirst = false;
                }
                currentSelector = temp;
                //list=new List<string>();
                //temp = new Selector();
            }

            Console.WriteLine();
            //root.Parent = null;
            return root;

        }

    }
}
