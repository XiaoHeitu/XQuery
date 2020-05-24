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

        public async Task<IXQueryElement> Get(string selector)
        {
            var guid = Guid.NewGuid().ToString("N");
            await jsRuntime.InvokeVoidAsync("xquery.get", selector, guid);
            return new XQueryElement(this, guid);
        }
    }
}
