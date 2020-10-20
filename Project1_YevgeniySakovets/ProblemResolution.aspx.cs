using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace Project1_YevgeniySakovets
{
    public partial class ProblemResolution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //check if page is being loaded for the first time or is responding to a postback
            {
                lblError.Text = ""; //clear out error text
                LoadProblems(); //load problems into datagrid view
            }
        }

        private void LoadProblems()
        {
            DataSet dsData;

            dsData = clsDatabase.GetProblems();
            if (dsData == null)
            {
                lblError.Text = "Error retrieving problem list";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving problem list";
                dsData.Dispose();
            }
            else
            {
                gvResolutions.DataSource = dsData.Tables[0];
                gvResolutions.DataBind();

                dsData.Dispose();
            }
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx"); //redirects page back to main menu
        }

        protected void gvResolutions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Boolean blnErrorOccurred = false;
            String strTicketNo = ""; //create variable to store ticket number
            String strProblemNo = ""; //create variable to store problem number

            lblError.Text = ""; //clear error text

            if (e.CommandName.Trim().ToUpper() == "SELECT")
            {
                try
                {
                    strTicketNo = gvResolutions.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.ToString(); //assigns problem number from datagridview into this variable
                    strProblemNo = gvResolutions.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.ToString(); //assigns ticket number from datagridview into this variable
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    lblError.Text = "Unable to access problem id";
                }

                if (!blnErrorOccurred) //if no errors occured, proceed to store problem and ticket numbers into session variables below
                {
                    //** using SESSION variables
                    Session["ProblemNo"] = strProblemNo; //store problem number into session variable "ProblemNo"
                    Session["TicketNumber"] = strTicketNo; //store ticket number into session variable "TicketNumber"
                    Response.Redirect("ResolutionEntry.aspx"); //redirect to resolution entry page
                }
            }
        }
    }
}