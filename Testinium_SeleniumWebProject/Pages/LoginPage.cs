using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testinium_SeleniumWebProject.Collection;

namespace Testinium_SeleniumWebProject.Pages
{
    public class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(BaseCollection.webDriver, this);
        }

        #region Ekran Bileşenleri Tanımlandı.
        [FindsBy(How = How.Id, Using = "L-UserNameField")]
        public IWebElement txtKullaniciAdi { get; set; }

        [FindsBy(How = How.Id, Using = "L-PasswordField")]
        public IWebElement txtParola { get; set; }

        [FindsBy(How = How.Id, Using = "gg-login-enter")]
        public IWebElement btnGirisYap { get; set; }
        #endregion


        #region Oturum Açma metotu oluşturuldu.
        public void SignIn(string kullaniciAdi, string parola)
        {
            txtKullaniciAdi.SendKeys(kullaniciAdi);
            txtParola.SendKeys(parola);
            btnGirisYap.Click();
        }
        #endregion
    }
}
