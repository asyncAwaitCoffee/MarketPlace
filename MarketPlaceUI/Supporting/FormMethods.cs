using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceUI.Supporting
{
    public static class FormMethods
    {
        public static void RemoveControlByGrandChild(Control control)
        {
            Control? parent = control.Parent;
            if (parent != null)
            {
                parent.Controls.Remove(control);
            }
        }
    }
}
