using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;

namespace Touz
{
    class Program
    {
        static PhantomJSDriver Driver;
        static User user;
        const string BASE_PATH = "https://www.instagram.com/";

        public static void GetPageSource(string username)
        {
            user = new User();

            var driverService = PhantomJSDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            Driver = new PhantomJSDriver(driverService);
            Driver.Url = BASE_PATH + username + "/";
            Driver.Navigate();
      
            try
            {
                user.Name = Driver.FindElementByClassName("rhpdm").Text;
            }
            catch (NoSuchElementException) { }

            try
            {
                user.About = Driver.FindElementByClassName("vDIg").FindElement(By.TagName("span")).Text;
            }
            catch (NoSuchElementException) { }

            try
            {
                user.Ref = Driver.FindElementByClassName("yLUwa").Text;
            }
            catch (NoSuchElementException) { }

            try
            {
                user.Avatar = Driver.FindElementByClassName("_6q-tv").GetAttribute("src"); // ссылка на аву
            }
            catch (NoSuchElementException) { }

            try
            {
                var listPhotos = Driver.FindElementsByClassName("v1Nh3");

                List<string> listUrlPhotos = new List<string>();

                foreach (var photo in listPhotos)
                {
                    var url = photo.FindElement(By.TagName("a")).GetAttribute("href");
                    listUrlPhotos.Add(url);
                }

                foreach(var urlPhoto in listUrlPhotos)
                {
                    setInfoPhoto(urlPhoto);
                }
            }
            catch (NoSuchElementException) { }

            Console.WriteLine(user.ToString());
            Driver.Close();
            Driver.Quit();
        }

        private static void setInfoPhoto(string url)
        {
            Driver.Url = url;
            Driver.Navigate();

            string fullSizeUrl, discription, location;

            try
            {
                fullSizeUrl = Driver.FindElementByClassName("FFVAD").GetAttribute("src");
            }
            catch (NoSuchElementException) { fullSizeUrl = null; }

            try
            {
                discription = Driver.FindElementByClassName("C4VMK").FindElement(By.TagName("span")).Text;
            }
            catch (NoSuchElementException) { discription = null; }

            try
            {
                location = Driver.FindElementByClassName("O4GlU").Text;
            }
            catch (NoSuchElementException) { location = null; }

            user.Photos.Add(new Photo(fullSizeUrl, discription, location));
        }

        static void Main(string[] args)
        {
            GetPageSource("p__uvarova");
            Console.ReadKey();
        }
    }
}
