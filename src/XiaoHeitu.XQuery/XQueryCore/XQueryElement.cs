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
        //public string Text
        //{
        //    get
        //    {
        //        return GetText().Result;
        //    }
        //    set
        //    {
        //        _ = SetText(value);
        //    }
        //}

        #region Text
        public IXQueryElement Text(string text)
        {
            TextAsync(text);
            return this;
        }
        public string Text()
        {
            return TextAsync().Result;
        }

        public async ValueTask<IXQueryElement> TextAsync(string text)
        {
            await xQuery.jsRuntime.InvokeVoidAsync("xquery.invoke", guid, "text", new string[] { text });
            return this;
        }
        public async ValueTask<string> TextAsync()
        {
            return await xQuery.jsRuntime.InvokeAsync<string>("xquery.invoke", guid, "text");
        }
        #endregion

        #region Find
        public IXQueryElement Find(string selector)
        {
            var cguid = Guid.NewGuid().ToString("N");
            xQuery.jsRuntime.InvokeAsync<string>("xquery.invoke", guid, "find", selector);
            return new XQueryElement(xQuery, cguid);
        }

        public async ValueTask<IXQueryElement> FindAsync(string selector)
        {
            var cguid = Guid.NewGuid().ToString("N");
            await xQuery.jsRuntime.InvokeAsync<string>("xquery.invoke", guid, "find", selector);
            return new XQueryElement(xQuery, cguid);
        }
        #endregion
    }
}
