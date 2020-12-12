using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using Saraswati.UI;

namespace Saraswati
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args) 
            => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        
        static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }
}