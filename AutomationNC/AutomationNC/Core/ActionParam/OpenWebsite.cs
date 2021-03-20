
namespace Core.ActionParam
{
    public class OpenWebsite
    {
        public string Browser { get; set; }
        public string Url { get; set; }

        public OpenWebsite(string browser, string url)
        {
            Browser = browser;
            Url = url;
        }
    }
}
