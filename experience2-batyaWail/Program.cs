using experience2_batyaWail;
using System.Text.RegularExpressions;
using System.Xml.Linq;

static async Task<string> Load(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(url);
    var html = await response.Content.ReadAsStringAsync();
    return html;
}
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
static void PrintHashSetHtmlElements(HashSet<HtmlElement> elements)
{
    foreach (var element in elements)
    {
        Console.WriteLine($"Tag Name: {element.Name}, ID: {element.Id}, Classes: {string.Join(", ", element.Classes)}, innerHtml: {element.InnerHtml}");
    }
}
static void PrintListHtmlElements(List<HtmlElement> elements)
{
    foreach (var element in elements)
    {
        Console.WriteLine($"Tag Name: {element.Name}, ID: {element.Id}, Classes: {string.Join(", ", element.Classes)}, innerHtml: {element.InnerHtml}");
    }
}
Console.WriteLine("----build the tree-parse html----");
var html = await Load("https://hebrewbooks.org/beis");
HtmlElement root =ParseHtml(html);
Console.WriteLine("----selectors----");
Selector selector1 = Selector.SavingQueryString("div");//21
Selector selector2 = Selector.SavingQueryString("div h2");//2
Selector selector3 = Selector.SavingQueryString("#outer form .mast");//1
Console.WriteLine("----descendants----");
List<HtmlElement> descendants = root.Descendants().ToList();
PrintListHtmlElements(descendants);
Console.WriteLine("----ancestors----");
List<HtmlElement> ancestors = root.Children[0].Children[0].Ancestors().ToList();
PrintListHtmlElements(ancestors);
Console.WriteLine("----find element (or elements list) from selector----");
HashSet<HtmlElement> all = root.FindElements(selector3);
PrintHashSetHtmlElements(all);