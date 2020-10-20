using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1_YevgeniySakovets
{
    public partial class ProblemResolution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //check if page is being loaded for the first time or is responding to a postback
            {
                lblError.Text = ""; //clear out error text
            }
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx"); //redirects page back to main menu
        }
    }
}