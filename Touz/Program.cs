using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace Touz
{
    class Program
    {
        public static void GetPageSource(string globalURL)
        {
            User user = new User();

            var driverService = PhantomJSDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var Driver = new PhantomJSDriver(driverService);
            Driver.Url = globalURL;
            Driver.Navigate();

            user.Name = Driver.FindElementByClassName("rhpdm").Text; // имя

            user.Avatar = Driver.FindElementByClassName("_6q-tv").GetAttribute("src"); // ссылка на аву

            var listRef = Driver.FindElementsByClassName("yLUwa"); // ссылка на соц сеть (ее может не быть)

            if(listRef.Count != 0)
            {
                user.Ref = Driver.FindElementByClassName("yLUwa").Text;
            }

            var listPhotos = Driver.FindElementsByClassName("v1Nh3");

            foreach(var photo in listPhotos)
            {
                var url = photo.FindElement(By.ClassName("FFVAD")).GetAttribute("src");
                user.Photos.Add(url);
            }

            Driver.Close();
            Driver.Quit();
        }

        static void Main(string[] args)
        {
            GetPageSource("https://www.instagram.com/deusmemes/");
        }
    }
}
