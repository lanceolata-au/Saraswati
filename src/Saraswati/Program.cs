using Gtk;
using Saraswati.UI;

namespace Saraswati
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.gtksharp.gtksharp", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new MainWindow();
            app.AddWindow(win);
            
            app.add

            win.Show();
            Application.Run();
        }
    }
}