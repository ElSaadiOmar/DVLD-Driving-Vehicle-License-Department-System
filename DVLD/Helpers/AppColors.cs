using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Helpers
{
    public static class AppColors
    {
        // -- Backgrounds --
        public static readonly Color NavyDark = Color.FromArgb(26, 58, 92);
        public static readonly Color NavyPrimary = Color.FromArgb(37, 99, 168);
        public static readonly Color PanelBg = Color.FromArgb(232, 240, 249);
        public static readonly Color GridRowAlt = Color.FromArgb(240, 245, 251); // صفوف متناوبة

        // -- Text --
        public static readonly Color TextLight = Color.FromArgb(230, 241, 251);
        public static readonly Color TextDark = Color.FromArgb(30, 30, 30);

        // -- Status --
        public static readonly Color Success = Color.FromArgb(45, 122, 58);
        public static readonly Color Danger = Color.FromArgb(192, 57, 43);
        public static readonly Color Warning = Color.FromArgb(122, 107, 61);
        public static readonly Color Inactive = Color.FromArgb(180, 178, 169);
    }
}
