using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void FileUpload1_DataBinding(object sender, EventArgs e)
        {
            lblTesteFileUpload.Text = FileUpload1.FileName.ToString();
        }

        protected void btnTesteFileUpload_Click(object sender, EventArgs e)
        {
            lblTesteFileUpload.Text = "Botão clicado...";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "TesteChamaCliqueFileUpload", "cliqueFileUpload();", true);
        }
    }
}