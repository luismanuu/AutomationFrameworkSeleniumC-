using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.Source.Drivers;
using PageObjectModel.Source.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PageObjectModel.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class HomeTests : Driver
    {

        [Test]
        public void SearchBook()
        {
            HomePage hp = new HomePage();
            _driver.Navigate().GoToUrl("http://amazon.com");
            hp.Search("c# book");
            Assert.True(_driver.Title.Contains("c# book"));
        }

        [Test]
        public void SearchSoftware()
        {
            HomePage hp = new HomePage();
            _driver.Navigate().GoToUrl("http://amazon.com");
            hp.ChangeDropdownSearch("Software");
            hp.Search("Antivirus ESET");
            Assert.True(_driver.Title.Contains("Antivirus ESET"));
        }

    }
}
