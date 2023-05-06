using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Source.Drivers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PageObjectModel.Source.Pages
{
    public class HomePage : Driver
    {
        
        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        private IWebElement? _searchTxtBox { get; set; }

        [FindsBy(How = How.Id, Using = "nav-search-submit-button")]
        private IWebElement? _searchBtn { get; set; }

        [FindsBy(How = How.Id, Using = "nav-link-accountList")]
        public IWebElement? _signInLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[aria-describedby='searchDropdownDescription']")]
        public IWebElement? _dropDownDescription { get; set; }
        public HomePage() {
            PageFactory.InitElements(_driver, this);
            InitializeElements(); 
        }

        private void InitializeElements()
        {
            PageFactory.InitElements(_driver, this);
            _ = _searchTxtBox ?? throw new NoSuchElementException("El elemento _searchTxtBox no fue encontrado en la página.");
            _ = _searchBtn ?? throw new NoSuchElementException("El elemento _searchTxtBtn no fue encontrado en la página.");
            _ = _signInLink ?? throw new NoSuchElementException("El elemento _signInLink no fue encontrado en la página.");
            _ = _dropDownDescription ?? throw new NoSuchElementException("El elemento _dropDownDescription no fue encontrado en la página.");
        }

        public void Search(string searchText)
        {
            _searchTxtBox?.SendKeys(searchText);
            _searchBtn?.Click();
        }

        public void ChangeDropdownSearch(string selectString)
        {
            SelectElement dropdown = new SelectElement(_dropDownDescription);
            dropdown.SelectByText(selectString);
        }
    }
}
