using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceUI
{
    internal static class UIFactory
    {
        // TODO - impl
        public static Button BuildButton(string name, string text, ButtonSize buttonSize)
        {
            Button button = new Button();

            button.BackColor = Color.SkyBlue;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            button.FlatStyle = FlatStyle.Flat;
            button.Location = new Point(64, 167);
            button.Name = name;
            button.Size = buttonSize switch
            {
                ButtonSize.Small => new Size(217, 42),
                ButtonSize.Medium => new Size(217, 42),
                ButtonSize.Large => new Size(217, 42),
                _ => new Size(217, 42)
            };
            button.TabIndex = 0;
            button.Text = text;
            button.UseVisualStyleBackColor = false;

            return button;
        }
    }

    internal enum ButtonSize
    {
        Small,
        Medium,
        Large,
    }
}
