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
    public partial class ResolutionEntry : System.Web.UI.Page
    {
        String strNoCharge; //create variable to store noCharge vaule
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //check if page has been loaded before
            {
                lblError.Text = ""; //clear out error text
                LoadTechnicians(); //load all technicians into the application 
                LoadNumbers(); //loads ticket, problem, and resolution numbers
            }
        }

        private void LoadNumbers() //loads problem, ticket, and resolution numbers onto form
        {
            Int32 intResolutionNo = 1; //resolution number always starts with 1

            lblProblemNo.Text = Convert.ToString(Session["ProblemNo"]); //use problem number from session variable
            lblTicketNo.Text = Convert.ToString(Session.Contents["TicketNumber"]); //use ticket number from session variable
            lblResolutionNo.Text = Convert.ToString(intResolutionNo); //convert resolution into a string and place into label
        }

        private void LoadTechnicians() //loads technicians into the applications
        {
            DataSet dsData; //create dataset

            dsData = clsDatabase.GetTechnicianList(); //attribute dataset to the GetTechnicianList database stored procedure
            if (dsData == null) //if dataset was null, show error message
            {
                lblError.Text = "Error retrieving Technician list";
            }
            else if (dsData.Tables.Count < 1) //check if there are any tables
            {
                lblError.Text = "Error retrieving Technician list"; //show error message
                dsData.Dispose(); //dispose of dataset
            }
            else //if dataset is not null and was successful, get technician list
            {
                drpTechnician.AppendDataBoundItems = true; //allows to add a new item into dropdown list
                drpTechnician.Items.Clear(); //clear items
                drpTechnician.DataSource = dsData.Tables[0]; //where we get our data from
                drpTechnician.DataTextField = "TechName"; //the full name of the technician is what we will see in the drop down menu as options
                drpTechnician.DataValueField = "TechnicianID"; //the techID is what the drop down list will be sorted by
                drpTechnician.Items.Add(new ListItem("-- Select Technician --", "0")); //create new list item, this will be the default one shown when application is loaded
                drpTechnician.DataBind(); //bind data in order that it all is connected and functions correctly

                dsData.Dispose(); //dispose of dataset
            }
        }


        private Boolean ValidateFields()
        {
            lblError.Text = ""; //clear out error label
            Boolean blnOk = true; //create boolean for verification and set to true

            if (drpTechnician.SelectedValue == "0") //check if user has selected a client
            {
                blnOk = false; //set false due to error
                if (String.IsNullOrWhiteSpace(lblError.Text)) //check if error message has anything in it
                {
                    lblError.Text = "Technician must be selected"; //if not, show this error message
                }
                else //if error label has something in it, concatenate additional error(s)
                {
                    lblError.Text += ", Technician must be selected"; //concatenate this to pre-existing error message
                }
            }

            if (String.IsNullOrWhiteSpace(txtResolution.Text)) //check if user entered anything into resolution textbox
            {
                blnOk = false; //set boolean to false
                if (String.IsNullOrWhiteSpace(lblError.Text)) //check if there are any labels
                {
                    lblError.Text = "Resolution is required";
                }
                else //if there is already something in the error label, add this one onto it
                {
                    lblError.Text += ", Resolution is required";
                }
            }

            if (String.IsNullOrWhiteSpace(txtHours.Text)) //check if user entered anything into hours textbox
            {
                blnOk = false; //set boolean to false
                if (String.IsNullOrWhiteSpace(lblError.Text)) //check if any errors exist
                {
                    lblError.Text = "Hours required";
                }
                else //if error already exists, add this one also
                {
                    lblError.Text += ", Hours required";
                }
            }

            Decimal decHours; //create double value for hours
            if (Decimal.TryParse(txtHours.Text, out decHours)) //check if user entered a numerical value
            {
                if (decHours <= 0) //check if hours is less than or equal to 0
                {
                    blnOk = false; //set boolean to false
                    if (String.IsNullOrWhiteSpace(lblError.Text)) //check if any errors exist
                    {
                        lblError.Text = "Hours must be greater than 0";
                    }
                    else //if errors already exist add this one also
                    {
                        lblError.Text += ", Hours must be greater than 0";
                    }
                    
                }
            }
            else //if user did not enter numerical value, apply error appropriately
            {
                blnOk = false; //set boolean to false
                if (String.IsNullOrWhiteSpace(lblError.Text)) //check if error label has any errors
                {
                    lblError.Text = "Hours must be numeric";
                }
                else //if error already exists, add this one also
                {
                    lblError.Text +=", Hours must be numeric";
                }
            }

            if (chkNoCharge.Checked) //check if user has checked the no charge checkbox
            {
                strNoCharge = "1"; //if no charge is selected then make value equal to 1
            }

            return blnOk; //return true or false for validation
        }

        private void ClearForm() //clears the form to default setting
        {
            lblError.Text = String.Empty;
            txtResolution.Text = String.Empty;
            drpTechnician.SelectedValue = "0";
            txtHours.Text = String.Empty;
            txtSupplies.Text = String.Empty;
            txtDateFixed.Text = String.Empty;
            txtMileage.Text = String.Empty;
            txtMisc.Text = String.Empty;
            txtCostMiles.Text = String.Empty;
            txtDateOnsite.Text = String.Empty;
            chkNoCharge.Checked = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e) //validate user input, if validation succeeds add data into database and increment resolution number for this particular problem
        {
            if (ValidateFields())
            {
                int intRetValue = clsDatabase.InsertResolution(Convert.ToInt32(lblTicketNo.Text.Trim()), Convert.ToInt32(lblProblemNo.Text.Trim()), Convert.ToInt32(lblResolutionNo.Text.Trim()), txtResolution.Text.Trim(), txtDateFixed.Text.Trim(), txtDateOnsite.Text.Trim(), Convert.ToInt32(drpTechnician.SelectedValue.Trim()), txtHours.Text.Trim(), txtMileage.Text.Trim(), txtCostMiles.Text.Trim(), txtSupplies.Text.Trim(), txtMisc.Text.Trim(), strNoCharge);

                if (intRetValue == 0) //check return value from database
                {
                    int intResolutionNo; //create resolution number integer to increment
                    if (Session["ResolutionNo"] != null) //check session variable
                    {
                        intResolutionNo = Convert.ToInt32(Session["ResolutionNo"]); //create new session variable for resolution number if one doesn't already exist
                    }
                    else //otherwise keep resolution number at 1 (default)
                    {
                        intResolutionNo = 1;
                    }

                    ClearForm();  //reset form for next entry
                    lblError.Text = "Ready for next resolution"; //let user know probelm addition was successful

                    intResolutionNo = intResolutionNo + 1; //increment resolution number
                    Session["ResolutionNo"] = intResolutionNo;  //update session variable 
                    lblResolutionNo.Text = intResolutionNo.ToString(); //update problemNo label
                }
                else
                {
                    lblError.Text = "Error adding resolution to database"; //display error message if something goes wrong when attempting to add to database
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e) //calls upon the clear form function
        {
            ClearForm(); //clears form
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProblemResolution.aspx"); //redirects back to page with problem gridview
        }
    }
}