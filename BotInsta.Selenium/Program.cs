using OpenQA.Selenium;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Configuration;
using System.Threading;

namespace BotInsta.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = ConfigurationManager.AppSettings.Get("usuario");
            var password = ConfigurationManager.AppSettings.Get("senha");

            var url = "https://www.instagram.com/accounts/login/?source=auth_switcher";
            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(
                Browser.Chrome, @"C:\Users\Wilkson Cardoso\Documents\Projetos\robos\selenium\drive");

            try
            {
                webDriver.LoadPage(TimeSpan.FromSeconds(10), url);
                webDriver.WaitFindElement(By.Name("username"), 10);
                webDriver.WaitFindElement(By.Name("password"), 10);

                webDriver.SetText(By.Name("username"), username);
                webDriver.SetText(By.Name("password"), password);
                webDriver.Submit(By.TagName("button"));

                Thread.Sleep(TimeSpan.FromSeconds(2));
                webDriver.FindElement(By.XPath("//button[contains(text(),'Not')]")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                webDriver.FindElement(By.XPath("//button[contains(text(),'Not')]")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                webDriver.LoadPage(TimeSpan.FromSeconds(10), @"https://www.instagram.com/wilkson.carlos");
                webDriver.FindElement(By.XPath("//button[contains(text(),'Follow')]")).Click();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                webDriver.Close();
                webDriver.Dispose();
            }
        }
    }
}
