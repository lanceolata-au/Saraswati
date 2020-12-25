using Gtk;
using Saraswati.Modbus;
using Saraswati.UI;

namespace Saraswati
{
    public static class Program
    {
        static void Main(string[] args)
        {
            /*Application.Init();

            var app = new Application("org.gtksharp.gtksharp", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new MainWindow();
            app.AddWindow(win);

            win.Show();
            Application.Run();*/
            
            var modbusTcp = new ModbusTCP();
            modbusTcp.Start();
            
        }
    }
}