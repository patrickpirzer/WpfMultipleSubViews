using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P16Admintool.Views
{
    public interface IView
    {
        event EventHandler<ViewClosingEventArgs> ViewCloseEvent;

    }
}
