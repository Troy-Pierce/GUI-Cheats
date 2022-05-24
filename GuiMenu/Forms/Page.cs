using System;
using System.Collections;
using System.Windows.Forms;

namespace Blueberry.Forms
{
    public class Page
    {
        public Func<bool> onOpenFunc = null;
        private ArrayList buttonList = new ArrayList();
        private Page parentPage;
        private String pageName;
        private Panel groupBox;
        private Menu menu;
        private MenuButton currentButton;
        public Page(String name, Menu menu, Page page)
        {
            this.menu = menu;
            this.pageName = name;
            this.parentPage = page;
            this.groupBox = new Panel();
            this.groupBox.BringToFront();
            this.groupBox.BackColor = System.Drawing.Color.Black;
            this.groupBox.ForeColor = System.Drawing.Color.White;
            this.groupBox.Location = new System.Drawing.Point(menu.guiForm.panel2.Location.X, menu.guiForm.panel2.Location.Y);
            this.groupBox.Name = name;
            this.groupBox.Size = new System.Drawing.Size(menu.guiForm.panel2.Size.Width, menu.guiForm.panel2.Size.Height);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = name;
            this.groupBox.Visible = false;
            this.groupBox.Enabled = false;
            this.groupBox.VerticalScroll.Enabled = true;
            this.groupBox.VerticalScroll.Visible = false;
            menu.guiForm.Controls.Add(this.groupBox);
        }

        public MenuButton CreateButton(String text, TYPE type)
        {
            MenuButton button = new MenuButton(text, this, type);
            this.groupBox.Controls.Add(button.GetPanel());
            this.buttonList.Add(button);
            if (this.currentButton == null)
            {
                this.SetButton(button);
            }
            this.GetGroup().VerticalScroll.Maximum = this.GetGroup().VerticalScroll.Maximum+button.GetPanel().Size.Height;
            return button;
        }
        public void RemoveButton(MenuButton button)
        {
            if(this.buttonList.IndexOf(button) != this.buttonList.Count - 1)
            {
                for(int i = this.buttonList.IndexOf(button); i<this.buttonList.Count-1; i++)
                {
                    ((MenuButton)this.buttonList[i]).GetPanel().Location = new System.Drawing.Point(((MenuButton)this.buttonList[i]).GetPanel().Location.X, ((MenuButton)this.buttonList[i]).GetPanel().Location.Y-button.GetPanel().Height);
                }
            }
            this.groupBox.Controls.Remove(button.GetPanel());
            this.buttonList.Remove(button);
            this.GetGroup().VerticalScroll.Maximum = this.GetGroup().VerticalScroll.Maximum - button.GetPanel().Size.Height;
            if(button.getButtonType() == TYPE.PAGE)
            {
                if(menu.GetCurrentPage() == button.page)
                {
                    menu.OpenPage(button.parentPage);
                }
            }
        }

        public void NextButton()
        {
            try
            {
                if (this.buttonList.Count >= this.buttonList.IndexOf(currentButton))
                {
                    MenuButton nextButtonInList = (MenuButton)this.buttonList[this.buttonList.IndexOf(currentButton) + 1];
                    this.SetButton(nextButtonInList);
                }
                else{
                    if (this.buttonList.Count > 0)
                    {
                        this.SetButton((MenuButton)this.buttonList[0]);
                    }
                }
            }catch(Exception e)
            {
                if (this.buttonList.Count > 0)
                {
                    this.SetButton((MenuButton)this.buttonList[0]);
                }
            }
        }

        public void PreviousButton()
        {
            try
            {
                MenuButton previousButtonInList = (MenuButton)this.buttonList[this.buttonList.IndexOf(currentButton) - 1];
                this.SetButton(previousButtonInList);
            }catch(Exception e)
            {
                if (this.buttonList.Count > 0)
                {
                    this.SetButton((MenuButton)this.buttonList[this.buttonList.Count-1]);
                }
            }
        }
        int scrollbarY = 0;
        public void SetButton(MenuButton button)
        {
            if (this.currentButton != null)
            {
                this.currentButton.GetPanel().BackColor = System.Drawing.Color.Black;
            }
            button.GetPanel().BackColor= System.Drawing.Color.Maroon;
            this.currentButton = button;
            this.getMenu().guiForm.Page.Text = this.GetName() + " - " + (this.GetButtons().IndexOf(this.GetCurrentButton()) + 1) + "/" + this.GetButtons().Count;
            if (Math.Abs(button.GetPanel().Bottom) > this.GetGroup().Size.Height)
            {
                scrollbarY += Math.Abs(this.GetGroup().Size.Height - button.GetPanel().Bottom);
                this.GetGroup().VerticalScroll.Value = scrollbarY;
            }else if (button.GetPanel().Top < 0)
            {
                try
                {
                    scrollbarY -= Math.Abs(button.GetPanel().Top);
                    this.GetGroup().VerticalScroll.Value = scrollbarY;
                }catch(Exception e)
                {
                    scrollbarY = 0;
                    this.GetGroup().VerticalScroll.Value = scrollbarY;
                }
            }

        }

        public MenuButton GetCurrentButton()
        {
            return this.currentButton;
        }

        public Panel GetGroup()
        {
            return this.groupBox;
        }

        public ArrayList GetButtons()
        {
            return this.buttonList;
        }


        internal void Close()
        {
            this.groupBox.Enabled = false;
            this.groupBox.Visible = false;
        }

        internal void Open()
        {
            this.onOpenFunc?.Invoke();
            this.GetGroup().VerticalScroll.Maximum = this.GetButtons().Count * 36;
            this.groupBox.Enabled = true;
            this.groupBox.Visible = true;
            this.groupBox.BringToFront();
            //try
            //{
            //    this.SetButton((MenuButton)this.buttonList[0]);
            //}catch(Exception e)
            //{
            //}
        }

        internal Page GetParentPage()
        {
            return this.parentPage;
        }

        public String GetName()
        {
            return this.pageName;
        }

        public Menu getMenu()
        {
            return this.menu;
        }
    }
}
