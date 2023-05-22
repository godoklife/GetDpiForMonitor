using System;
using System.Runtime.InteropServices;

namespace Win32App
{
    class Program
    {
        [DllImport("shcore.dll")]
        private static extern int GetDpiForMonitor(IntPtr hmonitor, MonitorDpiType dpiType, out uint dpiX, out uint dpiY);

        private enum MonitorDpiType
        {
            EffectiveDpi = 0,
            AngularDpi = 1,
            RawDpi = 2,
            Default = EffectiveDpi
        }

        static void Main(string[] args)
        {
            IntPtr primaryMonitor = IntPtr.Zero;
            uint dpiX, dpiY;
            int result = GetDpiForMonitor(primaryMonitor, MonitorDpiType.EffectiveDpi, out dpiX, out dpiY);
            
            Console.WriteLine($"result : {result}");
            
            if (result == 0)
            {
                Console.WriteLine("DPI (X): " + dpiX);
                Console.WriteLine("DPI (Y): " + dpiY);
                // 기본값은 96 -> 96/1.5(150%) = 64
            }
            else
            {
                Console.WriteLine("Failed to get DPI.");
            }

            Console.ReadLine();
        }
    }
}