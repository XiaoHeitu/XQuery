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
        /// <summary>
        /// wash宿主
        /// </summary>
        private static WebAssemblyHost host;

        /// <summary>
        /// 注入XQuery服务
        /// </summary>
        /// <param name="services">IOC服务集合</param>
        public static void AddXQuery(this IServiceCollection services)
        {
            services.AddTransient<XQuery>();
            services.AddSingleton<XQueryNavigationManager>();
        }

        /// <summary>
        /// 初始化XQuery服务
        /// </summary>
        /// <param name="host">wash宿主</param>
        public static void InitXQuery(this WebAssemblyHost host)
        {
            XQueryExtension.host = host;
            var nm = host.Services.GetService<XQueryNavigationManager>();
        }

        /// <summary>
        /// 选择对象
        /// </summary>
        /// <param name="cb">组件对象</param>
        /// <param name="selector">元素选择器</param>
        /// <returns>被选择的元素</returns>
        public static IXQueryElement XQ(this ComponentBase cb, string selector)
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
