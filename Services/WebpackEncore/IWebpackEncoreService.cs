using Microsoft.AspNetCore.Html;

namespace dotnet5_webpack_encore.Services.WebpackEncore
{
    public interface IWebpackEncoreService
    {
        HtmlString EntrypointStyle(string key);
        HtmlString EntrypointScript(string key, bool defer);
    }
}
