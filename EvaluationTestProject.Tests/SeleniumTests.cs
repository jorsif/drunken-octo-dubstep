using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace EvaluationTestProject.Tests
{
    [TestFixture]
    class SeleniumTests
    {
        [Test]
        public void PageRenders()
        {
            IWebDriver driver = new FirefoxDriver();
            
            //Thread.Sleep(10000);

            driver.Navigate().GoToUrl("http://localhost:60211");
            
            string link = driver.FindElement(By.CssSelector("[href*='/Home/Failure']")).Text;

            driver.Dispose();

            StringAssert.AreEqualIgnoringCase("Do Not Press", link);
        }
    }
}
