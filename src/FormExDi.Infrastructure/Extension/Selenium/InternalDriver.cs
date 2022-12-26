using System;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormExDi.Infrastructure.Extension.Selenium
{
    internal class InternalDriver : ChromeDriver
    {
        public InternalDriver(ChromeDriverService service, ChromeOptions options) 
            : base(service, options)
        {
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                this.ExecuteScript("return window.stop();");
            }
            catch { }
            base.Dispose(disposing);
        }
    }
}
