using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experience2_batyaWail
{
    public static class ExtensionToHtmlElement
    {
        #region MyRegion

        //public static List<HtmlElement> FindElementsRec(this HtmlElement h, HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
        //{
        //    if (htmlElement == null || selector == null)
        //        return listElements;

        //    bool isTheSameClass = true;

        //    if (!string.IsNullOrEmpty(selector.Id) && htmlElement.Id != selector.Id)
        //        return listElements;

        //    if (!string.IsNullOrEmpty(selector.TagName) && htmlElement.Name != selector.TagName)
        //        return listElements;

        //    if (selector.Classes != null)
        //    {
        //        if (htmlElement.Classes == null || selector.Classes.Count != htmlElement.Classes.Count)
        //            return listElements;

        //        for (int i = 0; i < selector.Classes.Count; i++)
        //        {
        //            if (selector.Classes[i] != htmlElement.Classes[i])
        //            {
        //                isTheSameClass = false;
        //                break;
        //            }
        //        }
        //    }

        //    if (isTheSameClass)
        //    {
        //        listElements.Add(htmlElement);
        //    }

        //    foreach (HtmlElement child in htmlElement.Descendants())
        //    {
        //        FindElementsRec(h, child, selector, listElements);
        //    }

        //    return listElements;
        //}

        //public static List<HtmlElement> FindElementsRec(this HtmlElement h, HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
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
        //    if (isTheSameClass && selector.Child != null)
        //    {
        //        //listElements.Add(htmlElement);
        //        foreach (HtmlElement child in htmlElement.Descendants())
        //        {
        //            return FindElementsRec(h, child, selector.Child, listElements);
        //        }
        //    }
        //    else
        //    {
        //        foreach (HtmlElement child in htmlElement.Descendants())
        //        {
        //            return FindElementsRec(h, child, selector, listElements);
        //        }
        //    }

        //    return listElements;

        //}
        //public static void FindElementsRec(this HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
        //{
        //    // Termination condition
        //    if (selector == null)
        //    {
        //        listElements.Add(htmlElement);
        //        //return listElements;
        //    }

        //    // Check if the current element matches the selector
        //    if (htmlElement.Id == selector.Id && htmlElement.Name == selector.TagName && htmlElement.Classes.SequenceEqual(selector.Classes))
        //    {
        //        // If child selector exists, call FindElementsRec recursively for each child
        //        if (selector.Child != null)
        //        {
        //            foreach (HtmlElement child in htmlElement.Descendants())
        //            {
        //                // Call recursively for each child
        //                FindElementsRec(child, selector.Child, listElements);
        //            }
        //        }
        //        else
        //        {
        //            // If no child selector, add the current element to the result list
        //            listElements.Add(htmlElement);
        //        }
        //    }
        //    else
        //    {
        //        // If the current element doesn't match the selector, continue searching descendants
        //        foreach (HtmlElement child in htmlElement.Descendants())
        //        {
        //            FindElementsRec(child, selector, listElements);
        //        }
        //    }

        //    //return listElements;
        //}
        //public static List<HtmlElement> FindElementsRec(this HtmlElement htmlElement, Selector selector)
        //{
        //    // Create a new list to hold elements found for this branch of recursion
        //    List<HtmlElement> listElements = new List<HtmlElement>();

        //    // Termination condition
        //    if (selector == null)
        //    {
        //        listElements.Add(htmlElement);
        //        return listElements;
        //    }

        //    // Check if the current element matches the selector
        //    if (htmlElement.Id == selector.Id && htmlElement.Name == selector.TagName && htmlElement.Classes.SequenceEqual(selector.Classes))
        //    {
        //        // If child selector exists, call FindElementsRec recursively for each child
        //        if (selector.Child != null)
        //        {
        //            foreach (HtmlElement child in htmlElement.Descendants())
        //            {
        //                // Add elements found by recursive calls to the local list
        //                listElements.AddRange(child.FindElementsRec(selector.Child));
        //            }
        //        }
        //        else
        //        {
        //            // If no child selector, add the current element to the result list
        //            listElements.Add(htmlElement);
        //        }
        //    }
        //    else
        //    {
        //        // If the current element doesn't match the selector, continue searching descendants
        //        foreach (HtmlElement child in htmlElement.Descendants())
        //        {
        //            // Add elements found by recursive calls to the local list
        //            listElements.AddRange(child.FindElementsRec(selector));
        //        }
        //    }

        //    return listElements;
        //}

        //public static List<HtmlElement> FindElementsRec(this HtmlElement htmlElement, Selector selector)
        //{
        //    var result = new List<HtmlElement>();

        //    Action<HtmlElement, Selector, List<HtmlElement>> findElementsRecursive = null;
        //    findElementsRecursive = (element, sel, res) =>
        //    {
        //        if (element == null || sel == null) return;

        //        // Check if the current element matches the selector
        //        if ((sel.TagName == null || element.Name == sel.TagName) &&
        //            (sel.Id == null || element.Id == sel.Id) &&
        //            (sel.Classes == null || sel.Classes.All(cssClass => element.Classes.Contains(cssClass))))
        //        {
        //            // If this is the last selector in the chain, add it to the result
        //            if (sel.Child == null)
        //            {
        //                res.Add(element);
        //                return;
        //            }

        //            // If not, continue recursion with the child selector
        //            foreach (var child in element.Children)
        //            {
        //                findElementsRecursive(child, sel.Child, res);
        //            }
        //        }

        //        // Continue recursion with descendants
        //        foreach (var child in element.Children)
        //        {
        //            findElementsRecursive(child, sel, res);
        //        }
        //    };

        //    findElementsRecursive(htmlElement, selector, result);
        //    return result;
        //}
        //public static IEnumerable<HtmlElement> FindElements(this HtmlElement html1,Selector selector)
        //{

        //    HashSet<HtmlElement> resultSet = FindElementsRecursive(html1, selector);

        //    return resultSet;
        //}// 

        //private static HashSet<HtmlElement> FindElementsRecursive(HtmlElement currentElement, Selector selector)
        //{
        //    HashSet<HtmlElement> resultSet = new HashSet<HtmlElement>();
        //    if (currentElement == null || selector == null)
        //    {
        //        return resultSet;
        //    }

        //    var elements = currentElement.Descendants<HtmlElement>(n => n.Children);

        //    foreach (var descendant in elements)
        //    {
        //        if (!string.IsNullOrEmpty(selector.Id) && selector.Id != descendant.Id)
        //        {
        //            continue;
        //        }
        //        if (!string.IsNullOrEmpty(selector.TagName) && selector.TagName != descendant.Name)
        //        {
        //            continue;
        //        }

        //        if (selector.Classes.Count > 0)
        //        {
        //            selector.Classes.ForEach(x =>
        //            {
        //                if (descendant.Classes.Contains(x))
        //                {

        //                    resultSet.Add(descendant);
        //                }
        //            });
        //        }
        //        else
        //        {
        //            if (selector.Id != null || selector.TagName != null)
        //            {
        //                resultSet.Add(descendant);
        //            }
        //        }
        //    }

        //    if (resultSet.Count > 0 && selector.Child != null)
        //    {
        //        foreach (var res in resultSet)
        //        {
        //            resultSet = FindElementsRecursive(res, selector.Child);
        //        }
        //    }
        //    else
        //    {
        //        return resultSet;
        //    }

        //    return resultSet;


        //last----------------last:
        /*
        public static List<HtmlElement> FindElementsRec(this HtmlElement h, Selector selector)
        {
            List<HtmlElement> listElements = new List<HtmlElement>();
            FindElementsRecHelper(h, selector, listElements);
            return listElements;
        }


        private static void FindElementsRecHelper(HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
        {
            if (htmlElement == null || selector == null)
                return;

            bool isTheSameClass = true;

            if (!string.IsNullOrEmpty(selector.Id) && htmlElement.Id != selector.Id)
                return;

            if (!string.IsNullOrEmpty(selector.TagName) && htmlElement.Name != selector.TagName)
                return;

            if (selector.Classes != null)
            {
                if (htmlElement.Classes == null || selector.Classes.Count != htmlElement.Classes.Count)
                    return;

                for (int i = 0; i < selector.Classes.Count; i++)
                {
                    if (selector.Classes[i] != htmlElement.Classes[i])
                    {
                        isTheSameClass = false;
                        break;
                    }
                }
            }

            if (isTheSameClass)
            {
                listElements.Add(htmlElement);
            }

            foreach (HtmlElement child in htmlElement.Descendants())
            {
                FindElementsRecHelper(child, selector, listElements);
            }
        }*/
        //public static List<HtmlElement> FindElementsRec(this HtmlElement h, Selector selector)
        //{
        //    List<HtmlElement> listElements = new List<HtmlElement>();
        //    FindElementsRecHelper(h, selector, listElements);
        //    return listElements;
        //}

        //private static void FindElementsRecHelper(HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
        //{
        //    if (htmlElement == null || selector == null)
        //        return;

        //    if (CheckingElementMatchesSelector(selector, htmlElement))
        //    {
        //        if (selector.Parent == null || MatchesSelectorRecursive(htmlElement, selector.Parent))
        //            listElements.Add(htmlElement);
        //    }

        //    foreach (HtmlElement child in htmlElement.Children)
        //    {
        //        FindElementsRecHelper(child, selector, listElements);
        //    }
        //}

        //private static bool MatchesSelectorRecursive(HtmlElement htmlElement, Selector selector)
        //{
        //    if (htmlElement == null || selector == null)
        //        return false;

        //    if (CheckingElementMatchesSelector(selector, htmlElement))
        //    {
        //        if (selector.Parent == null)
        //            return true;
        //        return MatchesSelectorRecursive(htmlElement.Parent, selector.Parent);
        //    }

        //    return false;
        //}

        //private static bool CheckingElementMatchesSelector(Selector selector, HtmlElement parent)
        //{
        //    if (!string.IsNullOrEmpty(selector.TagName) && parent.Name != selector.TagName)
        //        return false;

        //    if (!string.IsNullOrEmpty(selector.Id) && parent.Id != selector.Id)
        //        return false;

        //    if (selector.Classes != null)
        //    {
        //        foreach (var className in selector.Classes)
        //        {
        //            if (!parent.Classes.Contains(className))
        //                return false;
        //        }
        //    }

        //    return true;
        //    public static HashSet<HtmlElement> GetElementsBySelector(this HtmlElement element, Selector selector)
        //    {
        //        var result = new HashSet<HtmlElement>();
        //        var descendants = element.Descendants();

        //        foreach (var descendant in descendants)
        //        {
        //            if (CheckingElementMatchesSelector(selector, descendant))
        //            {
        //                List<HtmlElement> listParent = descendant.Ancestors().ToList();
        //                if (MatchesSelectorRecursive(listParent, 1, selector.Parent))
        //                    result.Add(descendant);
        //            }
        //        }
        //        return result;
        //    }
        //    private static bool MatchesSelectorRecursive(List<HtmlElement> listParent, int index, Selector selector)
        //    {
        //        if (index == listParent.Count())
        //            return false;
        //        if (CheckingElementMatchesSelector(selector, listParent[index]))
        //        {
        //            if (selector.Parent == null)
        //                return true;
        //            return MatchesSelectorRecursive(listParent, index + 1, selector.Parent);
        //        }
        //        return MatchesSelectorRecursive(listParent, index + 1, selector);
        //    }

        //    private static bool CheckingElementMatchesSelector(Selector selector, HtmlElement parent)
        //    {
        //        if (!string.IsNullOrEmpty(selector.TagName) && parent.Name != selector.TagName)
        //            return false;

        //        if (!string.IsNullOrEmpty(selector.Id) && parent.Id != selector.Id)
        //            return false;

        //        if (selector.Classes != null)
        //        {
        //            foreach (var className in selector.Classes)
        //            {
        //                if (!parent.Classes.Contains(className))
        //                    return false;
        //            }
        //        }

        //        return true;
        //    }/
        #endregion

        //הפונקציה שלנו

        //public static List<HtmlElement> FindElementsRec(this HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
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
        //    if (isTheSameClass && selector.Child != null)
        //    {
        //        //listElements.Add(htmlElement);
        //        foreach (HtmlElement child in htmlElement.Descendants())
        //        {
        //            return FindElementsRec(child, selector.Child, listElements);
        //        }
        //    }
        //    else
        //    {
        //        foreach (HtmlElement child in htmlElement.Descendants())
        //        {
        //            return FindElementsRec(child, selector, listElements);
        //        }
        //    }

        //    return listElements;

        //}




        //מיעל------------------------------------------

        //    public static HashSet<HtmlElement> GetElementsBySelector(this HtmlElement element, Selector selector)
        //    {
        //        var result = new HashSet<HtmlElement>();
        //        var descendants = element.Descendants();

        //        foreach (var descendant in descendants)
        //        {
        //            if (CheckingElementMatchesSelector(selector, descendant))
        //            {
        //                List<HtmlElement> listParent = descendant.Ancestors().ToList();
        //                if (MatchesSelectorRecursive(listParent, 1, selector.Parent))
        //                    result.Add(descendant);
        //            }
        //        }
        //        return result;
        //    }
        //    private static bool MatchesSelectorRecursive(List<HtmlElement> listParent, int index, Selector selector)
        //    {
        //        if (index == listParent.Count())
        //            return false;
        //        if (CheckingElementMatchesSelector(selector, listParent[index]))
        //        {
        //            if (selector.Parent == null)
        //                return true;
        //            return MatchesSelectorRecursive(listParent, index + 1, selector.Parent);
        //        }
        //        return MatchesSelectorRecursive(listParent, index + 1, selector);
        //    }

        //    private static bool CheckingElementMatchesSelector(Selector selector, HtmlElement parent)
        //    {
        //        if (!string.IsNullOrEmpty(selector.TagName) && parent.Name != selector.TagName)
        //            return false;

        //        if (!string.IsNullOrEmpty(selector.Id) && parent.Id != selector.Id)
        //            return false;

        //        if (selector.Classes != null)
        //        {
        //            foreach (var className in selector.Classes)
        //            {
        //                if (!parent.Classes.Contains(className))
        //                    return false;
        //            }
        //        }

        //        return true;
        //}


        //like yael
        //public static List<HtmlElement> FindElementsRec(this HtmlElement h, Selector selector)
        //{
        //    List<HtmlElement> listElements = new List<HtmlElement>();
        //    FindElementsRecHelper(h, selector, listElements);
        //    return listElements;
        //}

        //private static void FindElementsRecHelper(HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
        //{
        //    if (htmlElement == null || selector == null)
        //        return;

        //    if (CheckingElementMatchesSelector(selector, htmlElement))
        //    {
        //        if (selector.Parent == null || MatchesSelectorRecursive(htmlElement.Ancestors().ToList(), 0, selector.Parent))
        //            listElements.Add(htmlElement);
        //    }

        //    foreach (HtmlElement child in htmlElement.Descendants())
        //    {
        //        FindElementsRecHelper(child, selector, listElements);
        //    }
        //}

        //private static bool MatchesSelectorRecursive(List<HtmlElement> listParent, int index, Selector selector)
        //{
        //    if (index == listParent.Count())
        //        return false;
        //    if (CheckingElementMatchesSelector(selector, listParent[index]))
        //    {
        //        if (selector.Parent == null)
        //            return true;
        //        return MatchesSelectorRecursive(listParent, index + 1, selector.Parent);
        //    }
        //    return MatchesSelectorRecursive(listParent, index + 1, selector);
        //}

        //private static bool CheckingElementMatchesSelector(Selector selector, HtmlElement parent)
        //{
        //    if (!string.IsNullOrEmpty(selector.TagName) && parent.Name != selector.TagName)
        //        return false;

        //    if (!string.IsNullOrEmpty(selector.Id) && parent.Id != selector.Id)
        //        return false;

        //    if (selector.Classes != null)
        //    {
        //        foreach (var className in selector.Classes)
        //        {
        //            if (!parent.Classes.Contains(className))
        //                return false;
        //        }
        //    }

        //    return true;
        //}

        //try to fix my func of gpt: "15-02" 20:34

        //public static List<HtmlElement> FindElementsRec(this HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
        //{
        //    if (htmlElement == null || selector == null)
        //        return listElements;

        //    if (MatchesSelector(htmlElement, selector))
        //    {
        //        if (selector.Child == null)
        //        {
        //            listElements.Add(htmlElement);
        //        }
        //        else
        //        {
        //            foreach (HtmlElement child in htmlElement.Descendants())
        //            {
        //                FindElementsRec(child, selector.Child, listElements);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (HtmlElement child in htmlElement.Descendants())
        //        {
        //            FindElementsRec(child, selector, listElements);
        //        }
        //    }

        //    return listElements;
        //}

        //private static bool MatchesSelector(HtmlElement htmlElement, Selector selector)
        //{
        //    bool matches = true;

        //    if (selector.Id != null && htmlElement.Id != selector.Id)
        //        matches = false;

        //    if (selector.TagName != null && htmlElement.Name != selector.TagName)
        //        matches = false;

        //    foreach (string cssClass in selector.Classes)
        //    {
        //        if (!htmlElement.Classes.Contains(cssClass))
        //        {
        //            matches = false;
        //            break;
        //        }
        //    }

        //    return matches;
        //}

        //20:39
        //public static List<HtmlElement> FindElementsRec(this HtmlElement htmlElement, Selector selector)
        //{
        //    List<HtmlElement> listElements = new List<HtmlElement>();

        //    if (htmlElement == null || selector == null)
        //    {
        //        return listElements;
        //    }

        //    if (MatchesSelector(htmlElement, selector))
        //    {
        //        listElements.Add(htmlElement);
        //    }

        //    foreach (HtmlElement child in htmlElement.Descendants())
        //    {
        //        listElements.AddRange(child.FindElementsRec(selector.Child));
        //    }

        //    return listElements;
        //}

        //private static bool MatchesSelector(HtmlElement htmlElement, Selector selector)
        //{
        //    if (htmlElement.Id != selector.Id || htmlElement.Name != selector.TagName)
        //    {
        //        return false;
        //    }

        //    if (selector.Classes.Count > htmlElement.Classes.Count)
        //    {
        //        return false;
        //    }

        //    for (int i = 0; i < selector.Classes.Count; i++)
        //    {
        //        if (selector.Classes[i] != htmlElement.Classes[i])
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}


        //from rivki-- 15-02 20:51


        private static Selector LastChild(this HtmlElement htmlElement, Selector selector)
        {
            if (selector.Child == null)
                return selector;
            return LastChild(htmlElement, selector.Child);
        }


        public static HashSet<HtmlElement> FindElements(this HtmlElement htmlElement, Selector selector)
        {
            HashSet<HtmlElement> result = new HashSet<HtmlElement>();
            var items = htmlElement.Descendants();
            selector = LastChild(htmlElement, selector);
            foreach (var item in items)
            {
                if (item.IsSelectorEqual(selector))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        //body
        private static bool IsSelectorEqual(this HtmlElement htmlElement, Selector selector)
        {
            bool isPartFromSelectorEqual = IsPartFromSelectorEqual(selector, htmlElement);

            if (isPartFromSelectorEqual)
            {
                if (selector.Parent == null)
                    return true;
                if (htmlElement.Parent != null && selector.Parent != null)
                {
                    return IsSelectorEqualRec(htmlElement, selector.Parent, htmlElement.Parent);
                }
            }
            return false;
            
        }
        //private static bool IsSelectorEqualRec(this HtmlElement htmlElement, Selector selector, HtmlElement parent)
        //{
        //    if (selector.Parent == null && parent != null)
        //    {
        //        if (IsPartFromSelectorEqual(selector, parent))
        //            return true;
        //        else if (parent.Parent != null)
        //            return IsSelectorEqualRec(htmlElement, selector, parent.Parent);
        //        return false;
        //    }

        //    if (parent != null && parent.Parent != null && IsPartFromSelectorEqual(selector, parent))
        //        return IsSelectorEqualRec(htmlElement, selector.Parent, parent.Parent);
        //    else
        //        if (parent.Parent != null)
        //        return IsSelectorEqualRec(htmlElement, selector, parent.Parent);
        //    return false;
        //}

        private static bool IsSelectorEqualRec(this HtmlElement htmlElement, Selector selector, HtmlElement parent)
        {
            if (selector.Parent == null && parent != null)
            {
                if (IsPartFromSelectorEqual(selector, parent))
                    return true;
                else if (parent.Parent != null)
                    return IsSelectorEqualRec(htmlElement, selector, parent.Parent);
                return false;
            }

            if (parent != null && parent.Parent != null && IsPartFromSelectorEqual(selector, parent))
                return IsSelectorEqualRec(htmlElement, selector.Parent, parent.Parent);
            else
                if (parent.Parent != null)
                return IsSelectorEqualRec(htmlElement, selector, parent.Parent);
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

//21:33
//public static List<HtmlElement> FindElementsRec(this HtmlElement htmlElement, Selector selector)
//{
//    List<HtmlElement> listElements = new List<HtmlElement>();

//    if (htmlElement == null || selector == null)
//    {
//        return listElements;
//    }

//    FindElementsRecHelper(htmlElement, selector, listElements);

//    return listElements;
//}

//private static void FindElementsRecHelper(HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
//{
//    if (htmlElement == null || selector == null)
//    {
//        return;
//    }

//    if (htmlElement.Id == selector.Id && htmlElement.Name == selector.TagName && MatchClasses(htmlElement, selector.Classes))
//    {
//        listElements.Add(htmlElement);
//    }

//    if (selector.Child != null)
//    {
//        foreach (HtmlElement child in htmlElement.Descendants())
//        {
//            FindElementsRecHelper(child, selector.Child, listElements);
//        }
//    }
//}

//private static bool MatchClasses(HtmlElement htmlElement, List<string> classes)
//{
//    if (classes == null || classes.Count == 0)
//    {
//        return true;
//    }

//    if (htmlElement.Classes.Count != classes.Count)
//    {
//        return false;
//    }

//    for (int i = 0; i < classes.Count; i++)
//    {
//        if (htmlElement.Classes[i] != classes[i])
//        {
//            return false;
//        }
//    }

//    return true;
//}

//21:37
//public static List<HtmlElement> FindElementsRec(this HtmlElement htmlElement, Selector selector)
//{
//    List<HtmlElement> listElements = new List<HtmlElement>();

//    if (htmlElement == null || selector == null)
//    {
//        return listElements;
//    }

//    FindElementsRecHelper(htmlElement, selector, listElements);

//    return listElements;
//}

//private static void FindElementsRecHelper(HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
//{
//    if (htmlElement == null || selector == null)
//    {
//        return;
//    }

//    if (htmlElement.Id == selector.Id && htmlElement.Name == selector.TagName && MatchClasses(htmlElement, selector.Classes))
//    {
//        listElements.Add(htmlElement);
//    }

//    if (selector.Child != null)
//    {
//        foreach (HtmlElement child in htmlElement.Descendants())
//        {
//            FindElementsRecHelper(child, selector.Child, listElements);
//        }
//    }
//}

//private static bool MatchClasses(HtmlElement htmlElement, List<string> classes)
//{
//    if (classes == null || classes.Count == 0)
//    {
//        return true;
//    }

//    if (htmlElement.Classes.Count != classes.Count)
//    {
//        return false;
//    }

//    for (int i = 0; i < classes.Count; i++)
//    {
//        if (htmlElement.Classes[i] != classes[i])
//        {
//            return false;
//        }
//    }

//    return true;
//}

//21:43----rivki 2
//        public static List<HtmlElement> FindElementsRec(this HtmlElement htmlElement, Selector selector)
//        {
//            List<HtmlElement> listElements = new List<HtmlElement>();

//            if (htmlElement == null || selector == null)
//            {
//                return listElements;
//            }

//            FindElementsRecHelper(htmlElement, selector, listElements);

//            return listElements;
//        }

//        private static void FindElementsRecHelper(HtmlElement htmlElement, Selector selector, List<HtmlElement> listElements)
//        {
//            if (htmlElement == null || selector == null)
//            {
//                return;
//            }

//            // Check if the current element matches the selector
//            bool isMatch = IsElementMatch(htmlElement, selector);

//            // If the selector has no child, this is the last one, so add the element to the list if it matches
//            if (isMatch && selector.Child == null)
//            {
//                listElements.Add(htmlElement);
//            }

//            // Recursively process child elements
//            foreach (HtmlElement child in htmlElement.Children)
//            {
//                FindElementsRecHelper(child, selector.Child, listElements);
//            }
//        }

//        private static bool IsElementMatch(HtmlElement htmlElement, Selector selector)
//        {
//            if (htmlElement == null || selector == null)
//            {
//                return false;
//            }

//            // Check if element's properties match the selector
//            if (htmlElement.Id != selector.Id || htmlElement.Name != selector.TagName)
//            {
//                return false;
//            }

//            // Check if element's classes match the selector
//            if (selector.Classes != null && selector.Classes.Count > 0)
//            {
//                if (htmlElement.Classes == null || htmlElement.Classes.Count != selector.Classes.Count)
//                {
//                    return false;
//                }

//                for (int i = 0; i < selector.Classes.Count; i++)
//                {
//                    if (htmlElement.Classes[i] != selector.Classes[i])
//                    {
//                        return false;
//                    }
//                }
//            }

//            return true;
//        }





//    }

//}













//Compares and if they match adds to the HashSet








