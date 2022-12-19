using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormExDi.Infrastructure.Loger.Extension
{
    public static class LogDependencyInjection
    {
        public static IServiceCollection AddLog(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
