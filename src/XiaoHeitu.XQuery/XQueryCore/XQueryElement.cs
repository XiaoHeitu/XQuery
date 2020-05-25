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

        #region Text
        public IXQueryElement Text(string text)
        {
            xQuery.JsRuntime.InvokeVoid("xquery.invoke", guid, "text", new string[] { text });
            return this;
        }
        public string Text()
        {
            var result = xQuery.JsRuntime.Invoke<string>("xquery.invoke", guid, "text");
            return result;
        }

        public async ValueTask<IXQueryElement> TextAsync(string text)
        {
            await xQuery.JsRuntime.InvokeVoidAsync("xquery.invoke", guid, "text", new string[] { text });
            return this;
        }
        public async ValueTask<string> TextAsync()
        {
            return await xQuery.JsRuntime.InvokeAsync<string>("xquery.invoke", guid, "text");
        }
        #endregion

        #region Find
        public IXQueryElement Find(string selector)
        {
            var nguid = Guid.NewGuid().ToString("N");
            xQuery.JsRuntime.Invoke<string>("xquery.find", selector, nguid, guid);
            return new XQueryElement(xQuery, nguid);
        }

        public async ValueTask<IXQueryElement> FindAsync(string selector)
        {
            var nguid = Guid.NewGuid().ToString("N");
            await xQuery.JsRuntime.InvokeAsync<string>("xquery.find", selector, nguid, guid);
            return new XQueryElement(xQuery, nguid);
        }
        #endregion
    }
}
