using System.ComponentModel;
using System.Windows.Forms;
namespace Blueberry.Forms
{
    public partial class GroupBox : Panel
    {
        public GroupBox()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.UpdateStyles();
        }

        public GroupBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
