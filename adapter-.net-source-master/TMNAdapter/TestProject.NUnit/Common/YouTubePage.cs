using OpenQA.Selenium;
using TestProject.Core.Browser;

namespace TestProject.NUnit.Common
{
    public class YouTubePage
    {
        private static readonly By videoTitleLocator = By.ClassName("title");
        private static readonly By authorNameLocator = By.XPath("//*[@id = 'owner-name']//*");
        
        protected Browser _browser;

        public YouTubePage(string url)
        {
            _browser = new Browser();
            _browser.Maximise();
            _browser.NavigateTo(url);
        }

        public string GetVideoTitle()
        {
            return _browser.FindElement(videoTitleLocator).Text;
        }
        public string GetAuthorName()
        {
            return _browser.FindElement(authorNameLocator).Text;
        }
    }
}