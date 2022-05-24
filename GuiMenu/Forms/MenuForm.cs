using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blueberry.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            this.TransparencyKey = System.Drawing.Color.Bisque;
        }

        int mouseX = 0, mouseY = 0;

        private void MenuForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Button.HasFlag(MouseButtons.Left))
                {
                    this.SetDesktopLocation(MousePosition.X - this.mouseX, MousePosition.Y - this.mouseY);
                }
            }
        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void MenuForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseX = MousePosition.X - this.DesktopLocation.X;
            this.mouseY = MousePosition.Y - this.DesktopLocation.Y;
        }
    }
}
