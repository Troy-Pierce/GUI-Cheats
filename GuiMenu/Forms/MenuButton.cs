using System;
using System.Windows.Forms;

namespace Blueberry.Forms
{
    public enum TYPE
    {
        PAGE, CODE
    }
    public class MenuButton
    {
        
        public Page parentPage;
        String name;
        TYPE buttonType;
        public Func<bool> activationCode;
        public Func<bool> deactivationCode;
        internal bool isToggleable;
        internal bool isToggled;
        public Page page;
        private Panel panel;
        private Label panelLabel;
        private Label panelToggle;
        public MenuButton(String text, Page page, TYPE buttonType)
        {
            this.name = text;
            this.parentPage = page;
            this.buttonType = buttonType;
            this.panel = new Panel();
            this.panel.BringToFront();
            this.panel.BackColor = System.Drawing.Color.Black;
            this.panel.Name = text;
            this.panel.Size = new System.Drawing.Size(page.GetGroup().Size.Width, 36);
            if (this.parentPage.GetButtons().Count > 0)
            {
                this.panel.Location = new System.Drawing.Point(0, (((MenuButton)this.parentPage.GetButtons()[this.parentPage.GetButtons().Count - 1]).panel.Location.Y) + this.panel.Size.Height);
            }
            else
            {
                this.panel.Location = new System.Drawing.Point(0, 36);
            }
            this.panel.TabIndex = 0;
            this.panelLabel = new Label();
            this.panelLabel.AutoSize = true;
            this.panelLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelLabel.Location = new System.Drawing.Point(0, 0);
            this.panelLabel.Name = text+"Label";
            this.panelLabel.Size = new System.Drawing.Size(58, 20);
            this.panelLabel.TabIndex = 0;
            this.panelLabel.Text = text;
            this.panelToggle = new Label();
            this.panelToggle.Visible = false;
            this.panelToggle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelToggle.Location = new System.Drawing.Point((this.panelLabel.Location.X) + ((this.panel.Size.Width)/2), this.panelLabel.Location.Y);
            this.panelToggle.Text = "Disabled";
            this.panelToggle.Name = name + "Toggle";
            this.panelToggle.ForeColor = System.Drawing.Color.Red;
            this.panel.Controls.Add(this.panelLabel);
            this.panel.Controls.Add(this.panelToggle);
            this.parentPage.GetGroup().Controls.Add(this.panel);
        }

        internal void Activate()
        {
            switch (this.buttonType)
            {
                case TYPE.CODE:
                    if (this.isToggleable)
                    {
                        if (this.isToggled)
                        {
                            this.deactivationCode();
                            this.setEnabled(!this.isToggled);
                            break;
                        }
                        else
                        {
                            this.setEnabled(!this.isToggled);
                        }
                    }
                    this.activationCode();
                    break;
                case TYPE.PAGE:
                    this.page.getMenu().OpenPage(page);
                    break;
            }
        }

        public void setEnabled(bool b)
        {
            this.isToggled = b;
            if (b)
            {
                this.panelToggle.Text = "Enabled";
                this.panelToggle.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                this.panelToggle.Text = "Disabled";
                this.panelToggle.ForeColor = System.Drawing.Color.Red;
            }
        }

        public MenuButton setToggleableButton(bool b)
        {
            this.isToggleable = b;
            this.isToggled = false;
            this.panelToggle.Visible = b;
            return this;
        }

        internal bool isToggleButton()
        {
            return this.isToggleable;
        }

        internal Panel GetPanel()
        {
            return this.panel;
        }

        internal String getName()
        {
            return this.name;
        }

        public TYPE getButtonType()
        {
            return this.buttonType;
        }

        internal void DestroyButton()
        {

        }
    }
}
