using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Extensions;
using System.Collections.ObjectModel;
using System;

namespace NCLWebsiteTests
{
    /// <summary>
    /// This test using NUnit test adapter and the basic selenium chrome webdriver
    /// </summary>
    public class Tests
    {
        // private class variable - can be refactored into a browser class if we need multiple browser instances 
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //init driver with a new instance every time the test runs
            driver = new ChromeDriver();            

        }

        /// <summary>
        /// Test Scenario 1
        /// Guest explores Ports of Departure
        /// Implementing with Mockito for selenium web driver using Gravity Webdriver Mock package would improve performance as it would bypass the UI
        /// </summary>
        [Test]
        public void Scenario1()
        {
            driver.Navigate().GoToUrl("https://www.ncl.com");

            //delay for browser to navigate and load the page
            Thread.Sleep(2000);
            
            driver.Navigate().GoToUrl("https://www.ncl.com/port-of-call");

            //since we are navigating as guest, we can invoke links as there is no account info based page navigation involved
            Thread.Sleep(2000);

            //maximize browser and scroll the window a bit to indicate display map and search text input view together
            // Resolution can be detected and window intialized appropriately using a browser utility class
            driver.Manage().Window.Maximize();
            driver.ScrollBrowserWindow(300);

            // find the search  text and set the text and allow some delay for list to appear
            IWebElement element = driver.FindElement(By.XPath("//*[@id='searchbar']"));            
            element.Click();
            element.SendKeys("HONOLULU");
            Thread.Sleep(1000);

            // find the element by style class name attribute list-find-port and list all elements
            IWebElement portelements = driver.FindElement(By.ClassName("list-find-port"));
            ReadOnlyCollection<IWebElement> listitems = portelements.FindElements(By.XPath("//li[@class='ng-scope']"));
            //Find the first element displayed with an anchor hyperlink
            // navigating by class names always results in for-loops which can be avoided.
            foreach(var item in listitems)
            {
                if(item.Displayed && item.FindElement(By.TagName("a")).Displayed)
                {
                    item.Click();                    
                    break;
                }                                
            }

            //delay for click to be effective for on browser map event update
            Thread.Sleep(1000);

            // Exactly one item with + zoomin  should exist for the port as displayed element
            // This puts port in the middle of the map
            // putting an id for each list element with -number suffix would help us find more uniquely and for-loop can be avoided.
            ReadOnlyCollection<IWebElement> zoomElements = driver.FindElement(By.XPath("//div[@id='map-info']/div[@id='map-zoom']")).FindElements(By.XPath("//ul/li"));
            foreach (var item in zoomElements)
            {
                if (item.Displayed && item.GetAttribute("class").Contains("control-zoom-in"))
                {
                    item.Click();
                    break;
                }
            }

            //delay for click to be effective for on browser list update
            Thread.Sleep(2000);

            // Exactly one item with the given ballon image should exist for the port
            ReadOnlyCollection<IWebElement> imageElements = driver.FindElements(By.XPath("//div[@id='map-info']/div[@id='map-key']/ul/li/div/img[contains(@src,'pin-port-of-departure.png')]"));
            Assert.IsTrue(imageElements.Count == 1, "Port of departure could not be found on the map");
            element = imageElements[0].FindElement(By.XPath("//parent::*"));
            Console.WriteLine(element.Text);
            Assert.IsTrue(element.Text.ToLower().Contains("honolulu"), "Port of departure could not be verified");
        }

        [TearDown]
        public void TearDown()
        {
            //clean up browser and quit driver
            driver.Close();
            driver.Quit();
        }
    }
}