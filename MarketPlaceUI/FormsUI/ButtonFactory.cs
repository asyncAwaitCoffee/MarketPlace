﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceUI.FormsUI
{
    internal static class ButtonFactory
    {
        // TODO - impl
        public static Button BuildButton(string name, ButtonSize buttonSize, Point location, string text = "", DockStyle dockStyle = DockStyle.None, string imagePath = @"")
        {
            Button button = new Button();

            button.BackColor = UISettings.Colors[2];
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = UISettings.Colors[0];
            button.FlatStyle = FlatStyle.Flat;
            button.Location = location;
            button.Name = name;
            button.Margin = new Padding(1, 0, 1, 0);

            Debug.WriteLine(button.Padding);

            Debug.WriteLine($"imagePath: {imagePath}");

            if (imagePath.Length > 0 && File.Exists(imagePath))
            {
                Image image = Image.FromFile(imagePath);

                button.BackgroundImage = new Bitmap(image, 30, 30);
                button.BackgroundImageLayout = ImageLayout.Center;
                //button.Image = Image.FromFile(imagePath);                
            }

            (Size size, float fontSize) = buttonSize switch
            {
                ButtonSize.Tiny => (new Size(40, 40), 10F),
                ButtonSize.Small => (new Size(60, 40), 12F),
                ButtonSize.Medium => (new Size(200, 40), 14F),
                ButtonSize.Large => (new Size(300, 60), 16F),
                _ => (new Size(217, 42), 14F)
            };

            button.Font = new Font("Segoe UI", fontSize);

            button.Size = size;
            button.TabIndex = 0;
            if (text.Length > 0)
            {
                button.Text = text;
            }
            button.UseVisualStyleBackColor = false;
            button.Visible = true;
            button.Dock = dockStyle;

            return button;
        }
    }

    internal enum ButtonSize
    {
        Tiny,
        Small,
        Medium,
        Large,
    }
}
