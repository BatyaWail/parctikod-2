using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experience2_batyaWail
{
    public static class ExtensionToHtmlElement
    {

        //public static List<HtmlElement> FindElementsRec(this HtmlElement h,HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
        //{
        //    bool isTheSameClass = false;
        //    //if(htmlElement.Children == null)
        //    //    return listElements;
        //    if (selector == null)
        //    {
        //        listElements.Add(htmlElement);
        //        return listElements;
        //    }

        //    if (htmlElement.Id == selector.Id && htmlElement.Name == selector.TagName)
        //    {
        //        for (int i = 0; i < selector.Classes.Count; i++)
        //        {
        //            if (selector.Classes[i] == htmlElement.Classes[i])
        //            {
        //                isTheSameClass = true;
        //                break;
        //            }
        //        }
        //    }
        //    if (isTheSameClass&&selector.Child!=null)
        //    {
        //        //listElements.Add(htmlElement);
        //        foreach (HtmlElement child in htmlElement.Descendants())
        //        {
        //            return FindElementsRec(h,child, selector.Child, listElements);
        //        }
        //    }
        //    else
        //    {
        //        foreach (HtmlElement child in htmlElement.Descendants())
        //        {
        //            return FindElementsRec(h,child, selector, listElements);
        //        }
        //    }

        //    return null;

        //}
        public static List<HtmlElement> FindElementsRec(this HtmlElement htmlElement, HtmlElement root, Selector selector, List<HtmlElement> listElements)
        {
            if (selector == null)
            {
                listElements.Add(htmlElement);
                return listElements;
            }

            if (htmlElement.Id == selector.Id && htmlElement.Name == selector.TagName && htmlElement.Classes.SequenceEqual(selector.Classes))
            {
                if (selector.Child != null)
                {
                    foreach (HtmlElement child in htmlElement.Descendants())
                    {
                        return FindElementsRec(child, root, selector.Child, listElements);
                    }
                }
                else
                {
                    listElements.Add(htmlElement);
                }
            }
            else
            {
                foreach (HtmlElement child in htmlElement.Descendants())
                {
                    return FindElementsRec(child, root, selector, listElements);
                }
            }

            return listElements;
        }

    }
}

