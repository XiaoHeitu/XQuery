using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoHeitu.XQueryCore
{
    internal class XQueryNavigationManager
    {
        NavigationManager navigationManager;
        IJSInProcessRuntime jsRuntime;
        public XQueryNavigationManager(NavigationManager navigationManager, IJSRuntime jsRuntime)
        {
            this.navigationManager = navigationManager;
            this.jsRuntime=(IJSInProcessRuntime)jsRuntime;
            this.navigationManager.LocationChanged += (sender, e) =>
            {
                ResetDomMaps();
            };
        }

        private void ResetDomMaps()
        {
            jsRuntime.InvokeVoid("xquery.resetdommaps");
        }
    }
}
