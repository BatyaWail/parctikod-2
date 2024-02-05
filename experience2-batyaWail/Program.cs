using experience2_batyaWail;
using System.Text.RegularExpressions;
async Task<string> Load(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(url);
    var html = await response.Content.ReadAsStringAsync();
    return html;
}

var html = await Load("https://learn.malkabruk.co.il/practicode/projects/pract-2/#_2");
var cleanHtml = new Regex("\\s+").Replace(html, "");
var htmlLines = new Regex("<(.*?)>").Split(cleanHtml).Where(p => p.Length > 0).ToList();
Console.WriteLine();
HtmlElement root = new HtmlElement();
HtmlElement currentTag = new HtmlElement();
foreach(var line in htmlLines)
{
    if (line == "/html")
        break;
    if (line.StartsWith("/"))
    {
        
    }
    string word="", newLine;
    int index = line.IndexOf("=");
    bool isAlone = false;
    if ( index> 0)
    {
        word = line.Substring(0, index);
        isAlone = false;
    }
    else
    {
        word = line;
        isAlone = true;
    }
    if (HtmlHelper.Instance.htmlTags.ToList().Find(l => l==word)!=null)
    {
        HtmlElement temp = new HtmlElement();
        temp.Name = word;
        if (!isAlone)
        {
            newLine = line.Substring(index, line.Length - 1);
            var attributes = new Regex("([^\\s]*?)=\"(.*?)\"").Matches(newLine);
            string name = "", value = "";
            foreach (string a in attributes)
            {
                name = a.Substring(0, a.IndexOf("="));
                value = a.Substring(a.IndexOf("=") + 3, a.Length - 2);
                if (name == "ID" || name == "id")
                {
                    temp.Id = value;
                }
                else if (name == "class")
                {
                    temp.Classes = value.Split().ToList();
                }
                else
                {
                    temp.Attributes.Add(new Attributes() { Key = name, Value = value });
                }
            }
        }
        currentTag.Children.Add(temp);

    }




}