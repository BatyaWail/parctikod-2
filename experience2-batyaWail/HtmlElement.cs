﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experience2_batyaWail
{
    internal class HtmlElement
    {
        public string Id { get; set; }//????מאיפה מגיע
        public string Name { get; set; }
        //public List<Attributes> Attributes { get; set; }
        public List<string> Attributes { get; set; }
        public List<string> Classes { get; set; } = new List<string>();
        public string InnerHtml { get; set; }
        public HtmlElement Parent { get; set; }
        public List<HtmlElement> Children { get; set; }
        //public HtmlElement Children { get; set; }
        public HtmlElement()
        {
            Attributes = new List<string>();
            Children = new List<HtmlElement>();
        }


    }
}
