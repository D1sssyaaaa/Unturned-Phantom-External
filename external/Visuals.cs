using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UnturnedExternal
{
    public static class Visuals
    {
        public static void DrawBox(Graphics g, float x, float y, float w, float h, Color color, float thickness)
        {
            using (Pen pen = new Pen(color, thickness))
            {
                g.DrawRectangle(pen, x, y, w, h);
            }
        }

        public static void DrawString(Graphics g, string text, float x, float y, Color color, int size)
        {
            using (Font font = new Font("Segoe UI", size))
            {
                g.DrawString(text, font, new SolidBrush(color), x, y);
            }
        }

        public static void DrawHealthBar(Graphics g, float x, float y, float h, float health, float maxHealth)
        {
            float percentage = health / maxHealth;
            Color barColor = Color.FromArgb((int)(255 * (1 - percentage)), (int)(255 * percentage), 0);
            
            g.FillRectangle(Brushes.Black, x - 5, y, 3, h);
            g.FillRectangle(new SolidBrush(barColor), x - 5, y + (h * (1 - percentage)), 3, h * percentage);
        }
    }
}
