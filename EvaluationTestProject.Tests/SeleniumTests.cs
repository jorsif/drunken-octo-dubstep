using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace EvaluationTestProject.Tests
{
    [TestFixture]
    class SeleniumTests
    {
        [Test]
        public void PageRenders()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://localhost:60211";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until<IWebElement>((d => { return d.FindElement(By.CssSelector("[href*='/Home/Failure']")); }));
            
            string link = element.Text;

            driver.Dispose();

            StringAssert.AreEqualIgnoringCase("Do Not Press", link);
        }
    }
}
