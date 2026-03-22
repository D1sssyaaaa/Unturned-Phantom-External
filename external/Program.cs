using System;
using System.Windows.Forms;

namespace UnturnedExternal
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MemoryReader reader = new MemoryReader();
            
            MessageBox.Show("Запустите Unturned перед нажатием ОК", "Phantom External");

            if (reader.Connect("Unturned"))
            {
                // Запуск прозрачного оверлея
                Overlay overlay = new Overlay(reader);
                
                // Запуск меню (отдельным потоком или просто вторым окном)
                ModernMenu menu = new ModernMenu();
                menu.Show();

                Application.Run(overlay);
            }
            else
            {
                MessageBox.Show("Не удалось найти процесс Unturned!", "Ошибка");
            }
        }
    }
}
