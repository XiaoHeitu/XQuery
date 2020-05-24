using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoHeitu.XQueryCore
{
    public interface IXQueryElement
    {
        IXQueryElement Text(string text);
        string Text();
    }
}
