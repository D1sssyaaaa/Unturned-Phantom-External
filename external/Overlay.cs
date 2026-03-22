using System;
using System.Drawing;
using System.Windows.Forms;

namespace UnturnedExternal
{
    public class Overlay : Form
    {
        private MemoryReader _reader;
        private Timer _updateTimer;

        public Overlay(MemoryReader reader)
        {
            _reader = reader;
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            
            _updateTimer = new Timer();
            _updateTimer.Interval = 16; // ~60 FPS
            _updateTimer.Tick += (s, e) => this.Invalidate();
            _updateTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (Options.ESP_Enabled)
            {
                // Пример отрисовки ESP
                // 1. Получаем список игроков через _reader
                // 2. Для каждого игрока считаем ScreenPos
                // 3. Вызываем Visuals.DrawBox
            }
        }
    }
}
