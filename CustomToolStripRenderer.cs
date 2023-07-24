using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor {
    internal class CustomToolStripRenderer : ToolStripSystemRenderer {
        private Brush brush;

        public CustomToolStripRenderer(Color brushColor) {
            brush = new SolidBrush(brushColor);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) {
            //base.OnRenderToolStripBorder(e);
            e.Graphics.FillRectangle(brush, e.ConnectedArea);
        }
    }
}
