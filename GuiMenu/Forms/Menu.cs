using Blueberry.Forms;
using System;
using System.Collections;
using System.Windows.Forms;
using System.Windows.Threading;
namespace Blueberry
{
    public class Menu
    {
        ArrayList pageList = new ArrayList();
        Forms.Page currentPage;
        internal Forms.MenuForm guiForm;
        KeyBoardHook hook;
        bool running = true;
        Func<bool> exitFunction;
        internal Dispatcher dispatcher;
        public Menu(String game, Func<bool> exitFunction)
        {
            guiForm = new Forms.MenuForm();
            guiForm.GameLabel.Text = game;
            this.exitFunction = exitFunction;
            this.dispatcher = Dispatcher.CurrentDispatcher;
            this.hook = new KeyBoardHook(this);
            this.OpenMenu();
        }

        public Form GetGuiForm()
        {
            return this.guiForm;
        }

        public Forms.Page CreatePage(String name, Forms.Page parentPage, bool createButton)
        {
            Forms.Page page = new Forms.Page(name, this, parentPage);
            pageList.Add(page);
            if (this.currentPage == null)
            {
                this.currentPage = page;
            }
            if (parentPage != null && createButton)
            {
                parentPage.CreateButton(name, TYPE.PAGE).page = page;
            }
            return page;
        }

        public void OpenPage(Forms.Page page)
        {
            if (this.currentPage != null)
            {
                this.currentPage.Close();
            }
            page.Open();
            this.currentPage = page;
            this.guiForm.Page.Text = page.GetName() + " - " + page.GetButtons().IndexOf(page.GetCurrentButton()) + 1 + "/" + page.GetButtons().Count;
        }

        public void BackPage()
        {
            if (this.currentPage != null)
            {
                if (this.currentPage.GetParentPage() != null)
                {
                    this.currentPage.Close();
                    this.currentPage.GetParentPage().Open();
                    this.currentPage = this.currentPage.GetParentPage();
                    this.guiForm.Page.Text = this.currentPage.GetName();
                }
                else
                {
                    this.CloseMenu();
                }
            }
            else
            {
                this.currentPage = (Page) this.pageList[0];
            }
        }

        public Forms.Page GetCurrentPage()
        {
            return this.currentPage;
        }

        public void CloseMenu()
        {
            this.guiForm.Visible = false;
        }

        public void OpenMenu()
        {
            this.guiForm.Visible = true;
        }

        public bool isRunning()
        {
            return this.running;
        }

        public bool isOpen()
        {
            return this.guiForm.Visible;
        }

        public void ExitMenu()
        {
            this.running = false;
            this.exitFunction();
            this.guiForm.Close();
        }

    }
}
