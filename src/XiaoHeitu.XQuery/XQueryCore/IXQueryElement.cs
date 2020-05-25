using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XiaoHeitu.XQueryCore
{
    public interface IXQueryElement
    {
        IXQueryElement Text(string text);
        string Text();
        ValueTask<IXQueryElement> TextAsync(string text);
        ValueTask<string> TextAsync();

        IXQueryElement Find(string selector);
        ValueTask<IXQueryElement> FindAsync(string selector);
    }
}
