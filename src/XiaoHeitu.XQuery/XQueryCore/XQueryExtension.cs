using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop.WebAssembly;
using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoHeitu.XQueryCore
{
    public static class XQueryExtension
    {
        private static WebAssemblyHost host;

        public static void AddXQuery(this IServiceCollection services)
        {
            services.AddSingleton<XQuery>();
        }
        public static void UseXQuery(this WebAssemblyHost host)
        {
            XQueryExtension.host = host;
        }
        public static IXQueryElement XQ(this object obj, string selector)
        {
            var xQuery = host.Services.GetRequiredService<XQuery>();
            if (xQuery == null)
            {
                return null;
            }
            return xQuery.Find(selector);
        }
    }
}
