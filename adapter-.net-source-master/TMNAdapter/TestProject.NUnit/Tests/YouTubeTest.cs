using NUnit.Framework;
using TestProject.Core.Browser;
using TestProject.NUnit.Common;
using TMNAdapter.Tracking;
using TMNAdapter.Tracking.Attributes;
using TMNAdapter.Utilities;

namespace TestProject.NUnit.Tests
{
    [TestFixture]
    public class YouTubeTest 
    {
        protected Browser _browser;

        [SetUp]
        public void Initialize()
        {
            _browser = new Browser();
            Screenshoter.Instance.Initialize(_browser.Driver);
        }

        [Test]
        [JiraTestMethod("EPMFARMATS-2466")]
        [Parallelizable]
        public void AlwaysPassedTest()
        {
            YouTubePage page = new YouTubePage("https://www.youtube.com/watch?v=UKKYpdWPSL8");
            string author = page.GetAuthorName();

            JiraInfoProvider.SaveParameter("Author", author);
            JiraInfoProvider.SaveParameter("Title", page.GetVideoTitle());

            Assert.AreEqual(author, "EPAM Systems Global");
        }

        [Test]
        [JiraTestMethod("EPMFARMATS-2470")]
        [Parallelizable]
        public void AlwaysFailedTest()
        {
            YouTubePage page = new YouTubePage("https://www.youtube.com/watch?v=sU4i4DTr1HQ");
            string author = page.GetAuthorName();
            string title = page.GetVideoTitle();

            JiraInfoProvider.SaveParameter("Author", author);
            JiraInfoProvider.SaveParameter("Title", title);

            Screenshoter.Instance.TakeScreenshot();

            Assert.AreEqual("Atlassian", author);
        }

        [TearDown]
        public void Close()
        {
            Screenshoter.Instance.CloseScreenshoter();
            _browser.Quit();
        }
    }
}
