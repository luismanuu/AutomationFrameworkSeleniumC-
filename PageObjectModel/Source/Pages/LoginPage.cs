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
    public class LoginPage : Driver
    {
        [FindsBy(How = How.Id, Using = "ap_email")]
        private IWebElement? _emailTxt { get; set; }

        [FindsBy(How = How.Id, Using = "continue")]
        private IWebElement? _continueBtn { get; set; }

        [FindsBy(How = How.Id, Using = "ap_password")]
        private IWebElement? _passwordTxt { get; set; }

        [FindsBy(How = How.Id, Using = "signInSubmit")]
        private IWebElement? _signinBtn { get; set; }
        public LoginPage() {
            PageFactory.InitElements(_driver, this);
            InitializeElements();
        }

        private void InitializeElements()
        {
            PageFactory.InitElements(_driver, this);
            _ = _emailTxt ?? throw new NoSuchElementException("El elemento _emailTxt no fue encontrado en la página.");
            _ = _continueBtn ?? throw new NoSuchElementException("El elemento _continueBtn no fue encontrado en la página.");
            _ = _passwordTxt ?? throw new NoSuchElementException("El elemento _passwordTxt no fue encontrado en la página.");
            _ = _signinBtn ?? throw new NoSuchElementException("El elemento _signinBtn no fue encontrado en la página.");
        }

        public void Login(string user, string password)
        {
            HomePage hp = new HomePage();
            hp._signInLink?.Click();
            _emailTxt?.SendKeys(user);
            _continueBtn?.Click();
            _passwordTxt?.SendKeys(password);
            _signinBtn?.Click();
        }
    }
}
