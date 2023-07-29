using System.Drawing;

namespace LevelEditor {
    internal class DarkTheme {
        private static Color backgroundColor = Color.FromArgb(31, 31, 31);
        private static Color textColor = Color.White;

        public static Color BackgroundColor { get => backgroundColor; set => backgroundColor = value; }
        public static Color TextColor { get => textColor; set => textColor = value; }
    }
}
