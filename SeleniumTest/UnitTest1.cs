using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;
using System.IO;

namespace SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        string _dir = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "SeleniumTestPicture"); 

        [TestMethod]
        public void YahooTest()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Url = "http://yahoo.co.jp/";

                var e = driver.FindElement(By.Id("economy"));
                e.Click();
                SaveScreen(driver, _dir, "economy.png");

                e = driver.FindElement(By.Id("srchtxt"));
                e.SendKeys("Selenium");
                e.Submit();
                SaveScreen(driver, _dir, "srchtxt.png");
            }
        }

        private static void SaveScreen(IWebDriver driver, string dir, string fileName)
        {
            Directory.CreateDirectory(dir);
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(Path.Combine(dir, fileName), ImageFormat.Png);
        }
    }
}
