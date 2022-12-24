using FormExDi.Application.Model;
using FormExDi.Scrap.Quest.PiedadeMultasSelenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormExDi.Infrastructure.Extension.Selenium;

namespace FormExDi.Infrastructure.Queries.PiedadeMultas
{
    internal class PiedadeMultaSeleniumQuery : IPiedadeMultaSeleniumQuery
    {
        private const string url = "http://187.111.170.202:8081/";
        private const string urlMultas = "http://187.111.170.202:8081/Home/_Resultado?Placa={placa}&Renavam={renavam}";
        private readonly IWebDriver _driver;

        public PiedadeMultaSeleniumQuery(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

        public async Task<IEnumerable<InfracaoModel>> GetInfracoesAsync(string placa, string renavam, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            _driver.Navigate().GoToUrl(urlMultas.Replace("{placa}", placa).Replace("{renavam}", renavam));

            if (!_driver.GetElements($"//*[contains(text(), '{renavam.TrimStart('0')}')]").Any())
                throw new HttpRequestException("Placa not found in HTML.");

            if (_driver.GetElement($"//*[contains(text(), 'Não foram encontradas infrações')]") is not null)
                return Enumerable.Empty<InfracaoModel>();

            throw new NotImplementedException();
        }
    }
}
