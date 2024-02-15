using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace experience2_batyaWail
{
    internal class HtmlHelper
    {
        private readonly static HtmlHelper _instance = new HtmlHelper();
        public static HtmlHelper Instance => _instance;
        public string[] HtmlTags { get; set; }
        public string[] HtmlVoidTags { get; set; }


        private HtmlHelper()
        {
            var allHtmlTags = File.ReadAllText("HtmlTags.json");
            var htmlTagsWithoutClose = File.ReadAllText("HtmlVoidTags.json");
            HtmlTags = JsonSerializer.Deserialize<string[]>(allHtmlTags);
            HtmlVoidTags = JsonSerializer.Deserialize<string[]>(htmlTagsWithoutClose);
        }

    }
}
