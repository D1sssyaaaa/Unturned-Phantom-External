using System;
using System.Drawing;
using System.Drawing.Drawing2Interop;
using System.Windows.Forms;

namespace UnturnedExternal
{
    public class ModernMenu : Form
    {
        private Color _accentColor = Color.FromArgb(0, 255, 65); // Neon Green
        private Color _bgColor = Color.FromArgb(18, 18, 18); // Dark Graphite

        public ModernMenu()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = _bgColor;
            this.Size = new Size(350, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
        }

        private int _selectedTab = 0;
        private string[] _tabs = { "ESP", "AIMBOT", "MISC", "SETTINGS" };

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // BACKGROUND
            g.FillRectangle(new SolidBrush(_bgColor), 0, 0, this.Width, this.Height);

            // BORDER
            using (Pen pen = new Pen(_accentColor, 1))
            {
                g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }

            // SIDEBAR
            g.FillRectangle(new SolidBrush(Color.FromArgb(25, 25, 25)), 0, 0, 80, this.Height);
            for (int i = 0; i < _tabs.Length; i++)
            {
                Brush textBrush = (i == _selectedTab) ? new SolidBrush(_accentColor) : Brushes.Gray;
                g.DrawString(_tabs[i], new Font("Segoe UI", 8, FontStyle.Bold), textBrush, 15, 80 + (i * 50));
            }

            // CONTENT AREA
            g.DrawString(_tabs[_selectedTab].ToUpper(), new Font("Segoe UI", 12, FontStyle.Bold), Brushes.White, 100, 20);
            
            if (_selectedTab == 0) // ESP
            {
                DrawCheckbox(g, "Player ESP", 70, Options.ESP_Players);
                DrawCheckbox(g, "Item ESP", 100, Options.ESP_Items);
                DrawCheckbox(g, "Zombie ESP", 130, Options.ESP_Zombies);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.X < 80) // Sidebar click
            {
                int tabIndex = (e.Y - 80) / 50;
                if (tabIndex >= 0 && tabIndex < _tabs.Length)
                {
                    _selectedTab = tabIndex;
                    this.Invalidate();
                }
            }
        }

        private void DrawCheckbox(Graphics g, string text, int y, bool @checked)
        {
            g.DrawString(text, new Font("Segoe UI", 10), Brushes.LightGray, 50, y);
            Rectangle rect = new Rectangle(20, y + 2, 16, 16);
            g.DrawRectangle(new Pen(_accentColor, 1), rect);
            if (@checked)
            {
                g.FillRectangle(new SolidBrush(_accentColor), 23, y + 5, 10, 10);
            }
        }
    }
}
