using experience2_batyaWail;
using System.Text.RegularExpressions;
async Task<string> Load(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(url);
    var html = await response.Content.ReadAsStringAsync();
    return html;
}

var html = await Load("https://hebrewbooks.org/beis");
var cleanHtml = new Regex("\\s+").Replace(html, "");
var htmlLines = new Regex("<(.*?)>").Split(cleanHtml).Where(p => p.Length > 0).ToList();
Console.WriteLine();
HtmlElement root = new HtmlElement();
HtmlElement currentTag = root;
string id, classes;
foreach(var line in htmlLines)
{

    string[] tagName = line.Split(" ");
    if (line.StartsWith("/html"))
        break;
    if (line.StartsWith("/"))
    {
        currentTag = currentTag.Parent;
    }
    else
    {
        if (HtmlHelper.Instance.htmlTags.Contains(tagName[0]) || HtmlHelper.Instance.htmlVoidTags.Contains(tagName[0]))
        {
            HtmlElement htmlElement = new HtmlElement();
            htmlElement.Name = tagName[0];
            currentTag.Children.Add(htmlElement);
            htmlElement.Parent = currentTag;
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
                    currentTag.Attributes.Add(result);

                    //if (att.ToString().IndexOf("id=", 0) != -1)
                    //{
                    //    index = att.ToString().IndexOf("id=", 0);
                    //    currentElement.Id = att.ToString().Substring(index+3);
                    //}
                    //if (att.ToString().IndexOf("class=", 0) != -1)
                    //{

                    //}

                }
                if (currentTag.Attributes.Count > 0)
                {
                    id = currentTag.Attributes.Find((f) => f.Contains("id="));
                    if (id != null)
                        currentTag.Id = id.Substring(3);
                    classes = currentTag.Attributes.Find((f) => f.Contains("class="));
                    if (classes != null)
                    {
                        classes = classes.Substring(6);
                        string[] s = classes.Split(" ");
                        foreach (string s2 in s)
                        {
                            currentTag.Classes.Add(s2);
                        }
                    }

                }

            }
            if (!(line.EndsWith("/") && HtmlHelper.Instance.htmlVoidTags.Contains(line)))
            {
                currentTag = htmlElement;
            }
        }
        else
        {
            currentTag.InnerHtml = line;
        }
    }


}
Console.WriteLine(root);
Console.WriteLine("------------------");

Selector Selector=new Selector();
Selector.SavingQueryString("div#mydiv .class-name");


