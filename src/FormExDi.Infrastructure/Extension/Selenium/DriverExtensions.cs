using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormExDi.Infrastructure.Extension.Selenium
{
    internal static class DriverExtensions
    {
        public static IReadOnlyCollection<IWebElement> GetElements(this IWebDriver driver, string xpath)
        {
            return driver.FindElements(By.XPath(xpath));
        }

        public static IWebElement? GetElement(this IWebDriver driver, string xpath)
        {
            return driver.GetElements(xpath).FirstOrDefault();
        }
    }
}
