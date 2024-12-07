using Pharmagest.Dto.Company;
using Pharmagest.Interface.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pharmagest.WebClient
{
    public class WebClientContext : IWebClientContext
    {
        private readonly IEnumerable<IVatWebClient> _strategies;

        public WebClientContext(IEnumerable<IVatWebClient> strategies)
        {
            _strategies = strategies;
        }

        public CompanyDto ExecuteStrategy(string engineName, RequestVatDto requestVatDto)
        {
            var instance = _strategies.FirstOrDefault(x => x.Name.Equals(engineName, StringComparison.InvariantCultureIgnoreCase));
            return instance.GetCompany(requestVatDto);
        }


    }
}
