using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experience2_batyaWail
{
    public class HtmlElement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Attributes { get; set; }
        public List<string> Classes { get; set; } = new List<string>();
        public string InnerHtml { get; set; }
        public HtmlElement Parent { get; set; }
        public List<HtmlElement> Children { get; set; } = new List<HtmlElement>();
        public HtmlElement()
        {
            Attributes = new List<string>();
            Children = new List<HtmlElement>();
        }
        public IEnumerable<HtmlElement> Descendants()
        {
            Queue<HtmlElement> queueElements = new Queue<HtmlElement>();
            queueElements.Enqueue(this);
            while (queueElements.Count > 0)
            {
                HtmlElement element = queueElements.Dequeue();
                yield return element;
                foreach (HtmlElement child in element.Children)
                {
                    queueElements.Enqueue(child);
                }
            }
        }


        public IEnumerable<HtmlElement> Ancestors()
        {
            HtmlElement currentElement = this;
            while (currentElement.Parent != null)
            {
                currentElement = currentElement.Parent;
                yield return currentElement;
            }
        }



    }
}
