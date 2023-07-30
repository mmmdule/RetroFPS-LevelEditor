using System.Drawing;

namespace LevelEditor {
    internal class DarkTheme {
        private static Color backgroundColor = Color.FromArgb(31, 31, 31);
        private static Color textColor = Color.White;
        private static Color buttonHoverColor = Color.FromArgb(48, 48, 48);
        private static Color buttonMouseDownColor = Color.FromArgb(56, 56, 56);
        public static Color BackgroundColor { get => backgroundColor; }
        public static Color TextColor { get => textColor; }
        public static Color ButtonHoverColor { get => buttonHoverColor; }
        public static Color ButtonMouseDownColor { get => buttonMouseDownColor; }
    }
}
