using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experience2_batyaWail
{
    public static class ExtensionToHtmlElement
    {
        public static HashSet<HtmlElement> FindElements(this HtmlElement htmlElement, Selector selector)
        {
            HashSet<HtmlElement> result = new HashSet<HtmlElement>();
            var items = htmlElement.Descendants();
            selector = LastChild(htmlElement, selector);
            foreach (var item in items)
            {
                if (IsSelectorEqual(item, selector))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private static Selector LastChild(HtmlElement htmlElement, Selector selector)
        {
            if (selector.Child == null)
                return selector;
            return LastChild(htmlElement, selector.Child);
        }
        private static bool IsSelectorEqual(HtmlElement htmlElement, Selector selector)
        {
            bool isPartFromSelectorEqual = IsPartFromSelectorEqual(selector, htmlElement);

            if (isPartFromSelectorEqual)
            {
                if (selector.Parent == null)
                    return true;
                if (htmlElement.Parent != null && selector.Parent != null)
                {
                    return IsSelectorEqualRec(selector.Parent, htmlElement.Parent);
                }
            }
            return false;

        }
        private static bool IsSelectorEqualRec( Selector selector, HtmlElement parent)
        {
            if (selector.Parent == null && parent != null)
            {
                if (IsPartFromSelectorEqual(selector, parent))
                    return true;
                else if (parent.Parent != null)
                    return IsSelectorEqualRec( selector, parent.Parent);
                return false;
            }

            if (parent != null && parent.Parent != null && IsPartFromSelectorEqual(selector, parent))
                return IsSelectorEqualRec( selector.Parent, parent.Parent);
            else
                if (parent.Parent != null)
                return IsSelectorEqualRec(selector, parent.Parent);
            return false;
        }
        private static bool IsPartFromSelectorEqual(Selector selector, HtmlElement htmlElement)
        {
            bool isClassEqual = false;
            if (selector.TagName != null && htmlElement.Name != selector.TagName)
            {
                return false;
            }
            if (selector.Id != null && selector.Id != htmlElement.Id)
            {
                return false;
            }

            if (selector.Classes != null && selector.Classes.Count > 0)
            {
                foreach (var classSelector in selector.Classes)
                {
                    foreach (var classHtml in htmlElement.Classes)
                    {
                        if (classSelector == classHtml)
                            isClassEqual = true;
                    }
                    if (!isClassEqual)
                        return false;
                }
            }
            return true;
        }
    }
}









