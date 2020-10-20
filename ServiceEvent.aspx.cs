using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1_YevgeniySakovets
{
    public partial class ServiceEvent : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = ""; //clear out error text on page startup
            lblDateOfEvent.Text = DateTime.Now.ToString(); //get current date
        }

        private Boolean ValidateFields() //validate available fields so only good data comes through
        {
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
                    lblError.Text += "Phone number must be 10 digits";
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
                Response.Redirect("ProblemEntry.aspx");
            }
        }
    }
}