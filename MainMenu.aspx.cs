using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1_YevgeniySakovets
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnReports.Enabled = false; //disable reports button
        }

        protected void btnServiceEvent_Click(object sender, EventArgs e)
        {
            //response.redirect tells the browser "stop, we don't need to process anything else on this page and go to that new page"
            //you woudn't be able to go back a page using this function
            Response.Redirect("ServiceEvent.aspx"); //opens ServiceEvent page
        }

        protected void btnTechnician_Click(object sender, EventArgs e)
        {
            Response.Redirect("Technician.aspx"); //redirect to technican page
        }

        protected void btnProblemResolution_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProblemResolution.aspx"); //redirect to probelm resolution page
        }

        protected void btnReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports.aspx"); //redirect to reports page
        }
    }
}