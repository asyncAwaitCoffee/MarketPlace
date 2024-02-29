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
                Control? parentControl = parent.Parent;
                if (parentControl != null)
                {
                    parentControl.Controls.Remove(parent);
                }
            }
        }
    }
}
