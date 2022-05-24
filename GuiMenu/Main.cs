using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blueberry
{
    public static class Main
    {
        public static Menu CreateMenu(String game, Func<bool> exitFunction)
        {
            return new Menu(game, exitFunction);
        }
    }
}
