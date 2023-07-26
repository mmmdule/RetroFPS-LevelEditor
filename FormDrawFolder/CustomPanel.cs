using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LevelEditor
{
    internal class CustomPanel : Panel
    {
        //public ChildClass(ParentClass ch)
        //{
        //    foreach (var prop in ch.GetType().GetProperties())
        //    {
        //        this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(ch, null), null);
        //    }
        //}

        public CustomPanel(Panel parent)
        {
            PropertyInfo[] properties = typeof(Panel).GetProperties();

            foreach (PropertyInfo p in properties)
                if (p.CanRead && p.CanWrite)
                    p.SetMethod.Invoke(this, new object[] { p.GetMethod.Invoke(parent, null) });
            DoubleBuffered = true;
        }
    }
}
