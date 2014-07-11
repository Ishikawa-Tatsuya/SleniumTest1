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
        string _dir = @"C:\Users\tatsuya\Desktop\picture"; 

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
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(Path.Combine(dir, fileName), ImageFormat.Png);
        }


        public void YahooTestX()
        {
            /*
            WebDriver driver = new FirefoxDriver();

            // Access to Yahoo

            driver.get("http://yahoo.co.jp/");
            File scrFile = ((TakesScreenshot)driver).getScreenshotAs(OutputType.FILE);
            try
            {
                FileHandler.copy(scrFile, new File("/home/vagrant/screens/Y1.png"));
            }
            catch (IOException e1)
            {
                fail("file error 1");
            }

            // Click 'economy' link

            WebElement e = driver.findElement(By.id("economy"));
            e.click();

            scrFile = ((TakesScreenshot)driver).getScreenshotAs(OutputType.FILE);
            try
            {
                FileHandler.copy(scrFile, new File("/home/vagrant/screens/Y2.png"));
            }
            catch (IOException e2)
            {
                fail("file error 2");
            }

            // Search SKYSEA Client View

            e = driver.findElement(By.id("srchtxt"));
            e.sendKeys("Selenium");
            e.submit();

            scrFile = ((TakesScreenshot)driver).getScreenshotAs(OutputType.FILE);
            try
            {
                FileHandler.copy(scrFile, new File("/home/vagrant/screens/Y3.png"));
            }
            catch (IOException e3)
            {
                fail("file error 3");
            }

            try
            {
                e = driver.findElement(By.linkText("Selenium - Web Browser Automation"));
            }
            catch (NoSuchElementException ne)
            {
                fail("No Link for SKYSEA");
                driver.close();
            }
            e.click();

            // Now we see SKYSEA Client View's site

            scrFile = ((TakesScreenshot)driver).getScreenshotAs(OutputType.FILE);
            try
            {
                FileHandler.copy(scrFile, new File("/home/vagrant/screens/Y4.png"));
            }
            catch (IOException e4)
            {
                fail("file error 4");
            }

            // Done.

            driver.close();*/
        }
    }
}
