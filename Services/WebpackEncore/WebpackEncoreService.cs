using Microsoft.AspNetCore.Html;
using Newtonsoft.Json.Linq;
using System.IO;

namespace dotnet5_webpack_encore.Services.WebpackEncore
{
    public class WebpackEncoreService : IWebpackEncoreService
    {
        private string _entrypointFilePath;

        public WebpackEncoreService(string entrypointFilePath)
        {
            _entrypointFilePath = entrypointFilePath;
        }

        private dynamic GetEntrypoints()
        {
            return JObject.Parse(File.ReadAllText(_entrypointFilePath));
        }

        public HtmlString EntrypointStyle(string key)
        {
            string styleLinks = "";
            foreach(string cssSrc in GetEntrypoints().entrypoints[key].css)
            {
                styleLinks += $"<link rel=\"stylesheet\" href=\"{cssSrc}\">";
            }
            return new HtmlString(styleLinks);
        }

        public HtmlString EntrypointScript(string key, bool defer = false)
        {
            string scriptLinks = "";
            foreach (string jsSrc in GetEntrypoints().entrypoints[key].js)
            {
                scriptLinks += $"<script src=\"{jsSrc}\" {(defer ? "defer" : "")}></script>";
            }
            return new HtmlString(scriptLinks);
        }
    }
}
