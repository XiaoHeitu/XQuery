using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace XiaoHeitu.XQueryCore
{
    public class XQuery
    {
        internal IJSRuntime jsRuntime
        {
            get; set;
        }
        public XQuery(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public IXQueryElement Find(string selector)
        {
            var guid = Guid.NewGuid().ToString("N");
            jsRuntime.InvokeVoidAsync("xquery.find", selector, guid);
            return new XQueryElement(this, guid);
        }

        public async Task<IXQueryElement> FindAsync(string selector)
        {
            var guid = Guid.NewGuid().ToString("N");
            await jsRuntime.InvokeVoidAsync("xquery.find", selector, guid);
            return new XQueryElement(this, guid);
        }
    }
}
