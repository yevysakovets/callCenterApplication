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
    public partial class ServiceEvent : System.Web.UI.Page
    {
        String strEventDate = DateTime.Now.ToString(); //set datetime variable
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = ""; //clear out error text on page startup
                lblDateOfEvent.Text = DateTime.Now.ToString(); //get current date
                LoadClients(); //load clients into drop down menu
            }
            
        }

        private void LoadClients() //loads technicians into the applications
        {
            DataSet dsData; //create dataset

            dsData = clsDatabase.GetClientList(); //attribute dataset to the GetTechnicianList database stored procedure
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
                drpClient.AppendDataBoundItems = true; //allows to add a new item into dropdown list
                drpClient.Items.Clear(); //clear items
                drpClient.DataSource = dsData.Tables[0]; //where we get our data from
                drpClient.DataTextField = "ClientName"; //the full name of the technician is what we will see in the drop down menu as options
                drpClient.DataValueField = "ClientID"; //the techID is what the drop down list will be sorted by
                drpClient.Items.Add(new ListItem("-- Select Client --", "0")); //create new list item, this will be the default one shown when application is loaded
                drpClient.DataBind(); //bind data in order that it all is connected and functions correctly

                dsData.Dispose(); //dispose of dataset
            }
        }

        private Boolean ValidateFields() //validate available fields so only good data comes through
        {
            lblError.Text = ""; //clear out error label
            Boolean blnOk = true; //create and set boolean
            if (drpClient.SelectedValue == "0") //check if user has selected a client
            {
                blnOk = false; //set false due to error
                if (String.IsNullOrWhiteSpace(lblError.Text)) //check if error message has anything in it
                {
                    lblError.Text = "Client must be selected"; //if not, show this error message
                }
                else //if error label has something in it, concatenate additional error(s)
                {
                    lblError.Text += ", Client must be selected"; //concatenate this to pre-existing error message
                }
            }

            if (String.IsNullOrWhiteSpace(txtContact.Text)) //check if contact textbox is blank
            {
                blnOk = false; //if contact textbox is blank, set boolean to false
                if (String.IsNullOrWhiteSpace(lblError.Text)) //check if error label is empty
                {
                    lblError.Text = "Contact must be entered"; //if it is, make this the error message
                }
                else //if error label has something in it, concatenate additional error(s)
                {
                    lblError.Text += ", Contact must be entered"; //concatenate this to pre-existing error message
                }
            }

            if (txtPhone.Text.StartsWith("0")) //check is user entry begins with 0 for phone number
            {
                blnOk = false; //set boolean to false if it does
                if (String.IsNullOrWhiteSpace(lblError.Text)) //check if error message is blank
                {
                    lblError.Text = "Phone number cannot start with a 0"; //make this the error message if it is
                }
                else //if error label has something in it, concatenate additional error(s)
                {
                    lblError.Text += ", Phone number cannot start with a 0"; //concatenate this string to pre-existing erorr message
                }
            }

            if (txtPhone.Text.Length < 10) //check if phone number is less than 10 characters
            {
                blnOk = false; //set boolean due to error
                if (String.IsNullOrWhiteSpace(lblError.Text))
                {
                    lblError.Text = "Phone number must be 10 digits";
                }
                else
                {
                    lblError.Text += ", Phone number must be 10 digits";
                }
            }

            return blnOk; //return boolean value
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx"); //redirects browser back to the main menu page
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Int32 intTicketID; //create ticket
                lblError.Text = ""; //clear out error messages in case an error happens along the way

                intTicketID = clsDatabase.InsertServiceEvent(Convert.ToInt32(drpClient.SelectedValue), Convert.ToDateTime(strEventDate), txtPhone.Text, txtContact.Text); //insert service event into database
                if (intTicketID > 0) //if return value was not null / did not error out, enter data into database
                {
                    //if (Session["TicketID"] != null)
                    //{
                    //    intTicketID = Convert.ToInt32(Session["TicketID"]);
                    //}
                    //else
                    //{
                    //    intTicketID = 1;
                    //}
                    intTicketID = intTicketID++;
                    Session["TicketID"] = intTicketID;
                    Response.Redirect("ProblemEntry.aspx");
                }
                else
                {
                    lblError.Text = "Error inserting new Service Event"; //if return value was not 0, data was not entered, show error message
                }

                
            }
        }
    }
}