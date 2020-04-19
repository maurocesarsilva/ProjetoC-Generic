using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoWebForms.Admin.UserContol.Util
{
    public partial class ucAlertas : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowErrors(string message)
        {
            divErro.Visible = true;
            divErro.Focus();
            ltlErro.Text = message;
            FocusOntop();
        }

        public void ShowSuccess(string message)
        {
            divSucesso.Visible = true;
            divSucesso.Focus();
            ltlSucesso.Text = message;
            FocusOntop();
        }

        public void Clear()
        {
            divErro.Visible = false;
            divSucesso.Visible = false;
            divAlerta.Visible = false;
        }

        public void ClearError()
        {
            divErro.Visible = false;
        }

        public void ShowAlerta(string message)
        {
            divAlerta.Visible = true;
            divAlerta.Focus();
            ltlAlerta.Text = message;
            FocusOntop();
        }

        public bool errorHasMessage()
        {
            if (ltlErro.Text == "")
                return false;
            return true;
        }

        public void FocusOntop()
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "enviamsgbox", "$('html, body').animate({ scrollTop: 0 }, 200); ", true);
        }
    }
}