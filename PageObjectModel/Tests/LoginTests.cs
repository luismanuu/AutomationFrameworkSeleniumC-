
using PageObjectModel.Source.Pages;
using PageObjectModel.Source.Drivers;
using PageObjectModel.Source.Support;

namespace PageObjectModel.Tests
{
    [Parallelizable(ParallelScope.All)]

    public class LoginTests : Driver
    {

        [Test, TestCaseSource(typeof(Data), nameof(Data.GetTestData), new object[] { "Users.json" })]
        public void InvalidLogin(Dictionary<string, object> testData)
        {
            LoginPage lp = new LoginPage();
            _driver.Navigate().GoToUrl("http://amazon.com");
            lp.Login(testData["username"].ToString(), testData["password"].ToString());
            Assert.True(_driver.Title.Contains("Amazon Sign-In"));
        }
    }
}
