using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace XiaoHeitu.XQueryCore
{
    public class XQuery
    {
        private IJSInProcessRuntime jsRuntime;
        internal IJSInProcessRuntime JsRuntime
        {
            get
            {
                return jsRuntime;
            }
        }
        public XQuery(IJSRuntime jsRuntime)
        {
            this.jsRuntime = (IJSInProcessRuntime)jsRuntime;
        }

        public IXQueryElement Find(string selector)
        {
            var guid = Guid.NewGuid().ToString("N");
            var result = JsRuntime.Invoke<string>("xquery.find", selector, guid);
            return new XQueryElement(this, result);
        }

        public async ValueTask<IXQueryElement> FindAsync(string selector)
        {
            var guid = Guid.NewGuid().ToString("N");
            var result = await JsRuntime.InvokeAsync<string>("xquery.find", selector, guid);
            return new XQueryElement(this, result);
        }
    }
}
