using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace XiaoHeitu.XQueryCore
{
    public class XQueryElement : IXQueryElement
    {
        XQuery xQuery;
        string guid;
        internal XQueryElement(XQuery xQuery, string guid)
        {
            this.xQuery = xQuery;
            this.guid = guid;
        }
        public string Text
        {
            get
            {
                return GetText().Result;
            }
            set
            {
                _ = SetText(value);
            }
        }

        public async Task SetText(string text)
        {
            await xQuery.jsRuntime.InvokeVoidAsync("xquery.invoke", guid, "text", new string[] { text });
        }
        public async Task<string> GetText()
        {
            return await xQuery.jsRuntime.InvokeAsync<string>("xquery.invoke", guid, "text");
        }
    }
}
