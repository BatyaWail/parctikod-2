using experience2_batyaWail;
using System.Text.RegularExpressions;

var html = await Load("https://hebrewbooks.org/beis");

static HtmlElement ParseHtml(string htmlString)
{
    string id, cla;
    var cleanHtml = new Regex("\\s+").Replace(htmlString, " ");
    var htmlLines = new Regex("<(.*?)>").Split(cleanHtml).Where(s => s.Length > 0);
    HtmlElement rootElement = new HtmlElement();
    HtmlElement currentElement = rootElement;


    foreach (string line in htmlLines)
    {
        string[] tagName = line.Split(" ");
        if (line.StartsWith("/html"))
        {
            break;
        }
        else if (line.StartsWith("/"))
        {
            currentElement = currentElement.Parent;
        }

        else


            if (HtmlHelper.Instance.HtmlTags.Contains(tagName[0]) || HtmlHelper.Instance.HtmlVoidTags.Contains(tagName[0]))
        {
            HtmlElement htmlElement = new HtmlElement();
            htmlElement.Name = tagName[0];
            currentElement.Children.Add(htmlElement);
            htmlElement.Parent = currentElement;
            if (line.IndexOf(" ", 0) != -1)
            {
                int index;
                string attribute;
                attribute = line.Substring(line.IndexOf(" ", 0));

                var attributes = new Regex("([^\\s]*?)=\"(.*?)\"").Matches(attribute);
                string result = "";
                foreach (var att in attributes)
                {
                    foreach (var attr in att.ToString())
                    {
                        if (!(attr.Equals('\\') || attr.Equals('"')))
                            result += attr;
                    }
                    currentElement.Attributes.Add(result);

                }
                if (currentElement.Attributes.Count > 0)
                {
                    id = currentElement.Attributes.Find((f) => f.Contains("id="));
                    if (id != null)
                        currentElement.Id = id.Substring(3);
                    cla = currentElement.Attributes.Find((f) => f.Contains("class="));
                    if (cla != null)
                    {
                        cla = cla.Substring(6);
                        string[] s = cla.Split(" ");
                        foreach (string s2 in s)
                        {
                            currentElement.Classes.Add(s2);
                        }
                    }

                }

            }
            if (!(line.EndsWith("/") && HtmlHelper.Instance.HtmlVoidTags.Contains(line)))
            {
                currentElement = htmlElement;
            }
        }



        else
        {
            currentElement.InnerHtml = line;

        }

    }

    return rootElement;
}
static async Task<string> Load(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(url);
    var html = await response.Content.ReadAsStringAsync();
    return html;
}
static void PrintHtmlElements(HashSet<HtmlElement> elements)
{
    foreach (var element in elements)
    {
        Console.WriteLine($"Tag Name: {element.Name}, ID: {element.Id}, Classes: {string.Join(", ", element.Classes)}, innerHtml: {element.InnerHtml}");
    }
}

//Console.WriteLine(ParseHtml(html));
HtmlElement root =ParseHtml(html);
List<HtmlElement> htmlElements = root.Descendants().ToList();
List<HtmlElement> htmls = root.Children[0].Children[0].Ancestors().ToList();

Console.WriteLine("-------html-----------");

Selector Selector=new Selector();
Selector s= Selector.SavingQueryString("div");
HtmlElement htmlElement = new HtmlElement();
Console.WriteLine("-----------1-------");

List<HtmlElement> result=new List<HtmlElement>();
Console.WriteLine("--------2----------");

//HashSet<HtmlElement> elements = root.GetElementsBySelector(s);
//List<HtmlElement> elements = root.FindElementsRec(s,result);

HashSet<HtmlElement> all = root.FindElements(s);
//var all1 = root.FindElementsRec(s);
//foreach (var item in all)
//{
//    Console.WriteLine(item.InnerHtml + "\n ");
//}
PrintHtmlElements(all);

Console.WriteLine("----------3--------");

//foreach (HtmlElement element in elements)
//{
//    // Do whatever you need with the found elements
//    Console.WriteLine(element.Id);
//}



