using Microsoft.Extensions.DependencyInjection;
using System;

namespace SSExports
{
    public static class Configuration
    {
        public static IServiceCollection AddPdfServiceHiQ(this IServiceCollection service)
        {
            return service;
        }
    }
}
