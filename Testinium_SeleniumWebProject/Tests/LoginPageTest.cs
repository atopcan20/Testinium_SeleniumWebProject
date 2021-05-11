using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using Testinium_SeleniumWebProject.Collection;
using Testinium_SeleniumWebProject.Pages;

namespace Testinium_SeleniumWebProject.Tests
{
    [TestClass]
    public class LoginPageTest
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // TestInitialize anatasyonu test kodu yürütülmeden önce yapılacakları belirtmektedir.
        [TestInitialize]
        public void SetUp()
        {
            BaseCollection.webDriver = new FirefoxDriver();
            BaseCollection.webDriver.Manage().Window.Maximize();
            BaseCollection.webDriver.Navigate().GoToUrl(LoginCollection.mainUrl);
            Thread.Sleep(2000);
            BaseCollection.webDriver.FindElement(By.Name("profile")).Click();
            Thread.Sleep(2000);
            BaseCollection.webDriver.FindElement(By.XPath("/html/body/div[1]/header/div[3]/div/div/div/div[3]/div/div[1]/div[2]/div/div/div/a")).Click();
            Thread.Sleep(2000);

            string title = BaseCollection.webDriver.Title;

            Console.WriteLine("Sayfa başlığı {0} olan sayfa için test otomasyonu başlatıldı.", title);
            log.Info("Sayfa başlığı {0} olan sayfa için test otomasyonu başlatıldı.");

        }
        //Kullanıcı adı veya parolanın hatalı girildiği durum test edildi.
        [TestMethod]
        public void InCorrectLoginTest()
        {
            LoginPage loginPage = new LoginPage();
            // Kullanıcı adı veya parola hatalı gönderildi.
            loginPage.SignIn("alitopcan", "at2020");
            Thread.Sleep(2000);
            Console.WriteLine("InCorrectLoginTest başarıyla tamamlandı.");
            log.Info("InCorrectLoginTest başarıyla tamamlandı.");
        }

        //Kullanıcı adı ve parolanın doğru olduğu durum test edildi.
        [TestMethod]
        public void CorrectLoginTest()
        {
            LoginPage loginPage = new LoginPage();

            //Kullanıcı adı ve parola doğru gönderildi.
            loginPage.SignIn("alitopcann", "at2020");
            Thread.Sleep(2000);
            Console.WriteLine("CorrectLoginTest başarıyla tamamlandı.");
            log.Info("CorrectLoginTest başarıyla tamamlandı.");
        }

        [TestMethod]
        public void SearchTest()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.SignIn("alitopcann", "at2020");
            Thread.Sleep(2000);

            BaseCollection.webDriver.FindElement(By.Name("k")).SendKeys("bilgisayar");
            Thread.Sleep(2000);
            BaseCollection.webDriver.FindElement(By.XPath("/html/body/div[1]/header/div[3]/div/div/div/div[2]/form/div/div[2]/button")).Click(); //bul 
            Thread.Sleep(3000);
            //BaseCollection.webDriver.FindElement(By.ClassName("wis-clsbtn-92078")).Click();
            //Thread.Sleep(3000);
            BaseCollection.webDriver.FindElement(By.CssSelector("body > div.gray-content > div.policy-alert > div > div > a")).Click(); // kvkk close
            Thread.Sleep(5000);
            BaseCollection.webDriver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div[2]/div[5]/ul/li[2]/a")).Click(); //sayfa 2 geçiş
            Thread.Sleep(5000);

            Random rand = new Random();
            string locator = string.Format("product-title", rand.Next(3));
            BaseCollection.webDriver.FindElement(By.ClassName(locator)).Click();
            Thread.Sleep(4000);

            BaseCollection.webDriver.FindElement(By.Id("add-to-basket")).Click(); //sepete ekle
            Thread.Sleep(5000);
            BaseCollection.webDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[4]/div[3]/a")).Click(); //sepete git
            Thread.Sleep(5000);

            //SelectElement oSelect = new SelectElement(BaseCollection.webDriver.FindElement(By.ClassName("amount"))); // ürünü 1 artır
            //oSelect.SelectByIndex(1);
            //Thread.Sleep(5000);

            BaseCollection.webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/form/div/div[2]/div[2]/div[1]/div/div[6]/div[2]/div[2]/div[1]/div[3]/div/div[2]/div/a[1]/i")).Click(); //sepetten sil
            Thread.Sleep(5000);

            Console.WriteLine("SearchTest başarıyla tamamlandı.");
            log.Info("SearchTest başarıyla tamamlandı.");


        }


        //TestCleanup anatasyonu test kodu yürütüldükten sonra yapılacakları belirtmektedir.
        [TestCleanup]
        public void TearDown()
        {
            BaseCollection.webDriver.Quit();
            Console.WriteLine("Test otomasyonu sonlandırıldı...");
            log.Info("Program sonu");
        }
    }
}
