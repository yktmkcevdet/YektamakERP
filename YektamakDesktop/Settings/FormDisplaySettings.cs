using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YektamakDesktop.Settings
{
    public static class FormDisplaySettings
    {
        public enum WindowModes
        {
            Normal,
            Maximized
        }

        public static WindowModes WindowMode { get; set; } = WindowModes.Normal;
    }
}
