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
    public partial class Technician : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //check if page is being loaded for the first time or is responding to a postback
            {
                lblError.Text = ""; //clear out error text
                LoadTechnicians(); //load all technicians into the application
            }
        }
        private Boolean ValidateTech() //validates all applicable fields making sure data is acceptable into the database
        {
            lblError.Text = ""; //clear out error text
            Boolean blnOk = true; //boolean will check to see if user has input valid data

            if (String.IsNullOrWhiteSpace(txtFirstName.Text)) //checks to see if there is anything in first name textbox
            {
                blnOk = false;
                lblError.Text = "First name is required";
            }

            Double dblMidInit; //create temporary double to try parse
            if (!Double.TryParse(txtMiddleInit.Text, out dblMidInit))
            {
                //input was actually correct
            }
            else
            {
                blnOk = false;
                if (String.IsNullOrWhiteSpace(lblError.Text))
                {
                    lblError.Text = "Middle initial must be a letter";
                }
                else
                {
                    lblError.Text += "Middle initial must be a letter";
                }
            }

            if (String.IsNullOrWhiteSpace(txtLastName.Text)) //checks to see if there is anything in last name textbox
            {
                blnOk = false;
                if (String.IsNullOrWhiteSpace(lblError.Text)) //if error text is empty, put in error
                {
                    
                    lblError.Text = "Last name is required";
                }
                else //if there is already something in the error message, concatenate additional error
                {
                    lblError.Text += ", Last name is required";
                }
            }

            if (txtPhone.Text.StartsWith("0")) //check if phone number starts with 0
            {
                blnOk = false;
                if (String.IsNullOrWhiteSpace(lblError.Text)) //check if error text is empty, if so make this the error text
                {
                    lblError.Text = "Phone number cannot start with a 0";
                }
                else //concatenate error if there is already something there
                {
                    lblError.Text += ", Phone number cannot start with a 0";
                }
            }

            if (txtPhone.Text.Length < 10) //check to see if 
            {
                blnOk = false;
                if (String.IsNullOrWhiteSpace(lblError.Text))// check to see if error message has anything in it, apply appropriate error message
                {
                    lblError.Text = "Phone number must be 10 digits";
                }
                else //if there is already an error message, concatenate if necessary
                {
                    lblError.Text += ", Phone number must be 10 digits";
                }
            }

            Double dblHourlyRate; //create double to store value in
            if (Double.TryParse(txtHourlyRate.Text, out dblHourlyRate)) //make sure 
            {
                if (String.IsNullOrWhiteSpace(txtHourlyRate.Text)) //check if anything is entered into the textbox
                {
                    blnOk = false;
                    if (String.IsNullOrWhiteSpace(lblError.Text)) //check to see if error text is empty, if it is add this error message
                    {
                        lblError.Text = "Hourly rate is required";
                    }
                    else //concatenate error message if there is already something there
                    {
                        lblError.Text += ", Hourly rate is required";
                    }
                }

                if (dblHourlyRate <= 0) //check if hourly rate is greater than 0
                {
                    blnOk = false;
                    if (String.IsNullOrWhiteSpace(lblError.Text)) //check if error text is empty
                    {
                        lblError.Text = "Hourly rate must be greater than 0"; //make new erorr message if it was empty
                    }
                    else //concatenate if there was already an error message
                    {
                        lblError.Text += ", Hourly rate must be greater than 0";
                    }
                }
            }
            else //if entry was not able to be parsed to a number, show appropriate error message
            {
                blnOk = false;
                if (String.IsNullOrWhiteSpace(lblError.Text)) //check if error message is empty, if so add this error message
                {
                    lblError.Text = "Hourly rate must be numeric";
                }
                else //concatenate error message if something was already there
                {
                    lblError.Text += ", Hourly rate must be numberic";
                }
            }

            if (blnOk) //if boolean is true clear out error label
            {
                lblError.Text = "";
            }
            return blnOk; //return boolean if data is valid or not/ true or false
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

        private void DisplayTechnician(String drpTechnicianID) //Displays all technicians into the applictions
        {
            DataSet dsData; //create dataset
            
            dsData = clsDatabase.GetTechnicianByID(drpTechnicianID); //assign dataset to value of stored procedure
            if (dsData == null) //check if dataset is null
            {
                lblError.Text = "Error retrieving technician"; //show error message if dataset is null
            }
            else if (dsData.Tables.Count < 1) //check if table count is greater than 0
            {
                lblError.Text = "Error retrieving technician"; //show error message
                dsData.Dispose(); //dispose of error message
            }
            else //if dataset was not null and acceptable, display technician data in correct textboxes
            {
                
                if (dsData.Tables[0].Rows[0]["FName"] == DBNull.Value) //check if database null is the value for first name
                {
                    txtFirstName.Text = ""; //enter empty string is database null is the value found in database
                }
                else
                {
                    txtFirstName.Text = dsData.Tables[0].Rows[0]["FName"].ToString(); //otherwise enter first name data from database into textbox
                }

                if (dsData.Tables[0].Rows[0]["MInit"] == DBNull.Value) //check if database null is the value for middle initial
                {
                    txtMiddleInit.Text = "";//enter empty string is database null is the value found in database
                }
                else
                {
                    txtMiddleInit.Text = dsData.Tables[0].Rows[0]["MInit"].ToString(); //otherwise enter middle initial data from database into textbox
                }

                if (dsData.Tables[0].Rows[0]["LName"] == DBNull.Value) //check if last name has a database null value
                {
                    txtLastName.Text = ""; //enter empty string is database null is the value found in database
                }
                else
                {
                    txtLastName.Text = dsData.Tables[0].Rows[0]["LName"].ToString(); //enter last name data from database into textbox
                }

                if (dsData.Tables[0].Rows[0]["EMail"] == DBNull.Value) //check if email has a database null value
                {
                    txtEmail.Text = ""; //enter empty string is database null is the value found in database
                }
                else
                {
                    txtEmail.Text = dsData.Tables[0].Rows[0]["EMail"].ToString(); //enter email data from database into textbox
                }

                if (dsData.Tables[0].Rows[0]["Dept"] == DBNull.Value) //check if department has a database null value
                {
                    txtDepartment.Text = ""; //enter empty string is database null is the value found in database
                }
                else
                {
                    txtDepartment.Text = dsData.Tables[0].Rows[0]["Dept"].ToString(); //enter department data from database into textbox
                }

                if (dsData.Tables[0].Rows[0]["Phone"] == DBNull.Value) //check if phone has a database null value
                {
                    txtPhone.Text = ""; //enter empty string is database null is the value found in database
                }
                else
                {
                    txtPhone.Text = dsData.Tables[0].Rows[0]["Phone"].ToString(); //enter phone data from database into textbox
                }

                if (dsData.Tables[0].Rows[0]["HRate"] == DBNull.Value) //check if hourly rate has a database null value
                {
                    txtHourlyRate.Text = ""; //enter empty string is database null is the value found in database
                }
                else
                {
                    txtHourlyRate.Text = dsData.Tables[0].Rows[0]["HRate"].ToString(); //enter hourly rate data from database into textbox
                }


                dsData.Dispose(); //dipose of dataset
            }
        }

        private void InsertTechnician() //takes data from textboxes and enters them appropriately into the database
        {
            Int32 intRetValue; //return value

            lblError.Text = ""; //clear out error messages in case an error happens along the way

            intRetValue = clsDatabase.InsertTechnician(txtFirstName.Text.Trim(), txtMiddleInit.Text, txtLastName.Text.Trim(), txtEmail.Text.Trim(), txtDepartment.Text.Trim(), txtPhone.Text.Trim(), txtHourlyRate.Text.Trim());
            if (intRetValue == 0) //if return value was not null / did not error out, enter data into database
            {
                lblError.Text = "New Technician inserted"; //show user that the technician was entered
                drpTechnician.Enabled = true; //re-enable drop down menu list
            }
            else
            {
                lblError.Text = "Error inserting new Technician"; //if return value was not 0, data was not entered, show error message
            }
        }
        
        private void DeleteTechnician() //goes into the database, compares Technician ID you have selected in drop down menu and deletes that entry
        {
            Int32 intRetCode; //return value

            intRetCode = clsDatabase.DeleteTechnician(drpTechnician.SelectedValue.Trim()); //compare technician ID from drop down menu selection and delete that entry from database
            if (intRetCode.ToString() == "0") //check if return value was 0, if so it worked
            {
                LoadTechnicians(); //reload technicians in application
                lblError.Text = "Technician Deleted"; //let user know that technician was deleted
                ClearFields(); //clear out textboxes
            }
            else //if return value was something other than 0, technician was not deleted
            {
                lblError.Text = "Unable to remove product id"; //show error message explaining the problem
            }
        }

        private void UpdateTechnician() //comapres tech ID selected with same ID in database and updates changes related to that tech ID
        {
            Int32 intRetValue; //return value

            lblError.Text = ""; //clear out error text

            intRetValue = clsDatabase.UpdateTechnician(txtFirstName.Text.Trim(), txtMiddleInit.Text, txtLastName.Text.Trim(), txtEmail.Text.Trim(), txtDepartment.Text.Trim(), txtPhone.Text.Trim(), txtHourlyRate.Text.Trim(), drpTechnician.SelectedValue.Trim());
            if (intRetValue == 0) //if return value is 0, it worked
            {
                lblError.Text = "Technician updated"; //let user know technician was updated
                drpTechnician.Enabled = true; //re-enable drop down menu list
            }
            else //if return value was not 0, there was an error updating the technician
            {
                lblError.Text = "Error updating Technician"; //show error message
            }
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx"); //redirect page back to main menu page
        }

        protected void btnNewTechnician_Click(object sender, EventArgs e) //gets form ready to accept new data
        {
            drpTechnician.SelectedValue = "0"; //set default value to drop down menu list
            drpTechnician.Enabled = false; //disable drop down menu
            btnNewTechnician.Enabled = false; //disable new technician button
            btnRemove.Enabled = false; //disable remove button, there's nothing to remove
            ClearFields(); //clear out all fields
            LoadTechnicians(); //reload technicians
            lblError.Text = "Ready to enter new technician"; //let user know you're ready to enter new data
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            //ValidateTech(); //validates all user input to see if worthy to enter database

            if (ValidateTech()) //check if all values are valid for insertion / update
            {
                if (drpTechnician.SelectedValue == "0")
                {
                    InsertTechnician(); // insert technician if drop down menu is selected at 0
                }
                else
                {
                    UpdateTechnician(); //updates current technician
                }
            }

            LoadTechnicians(); //reload/update application to show updated information
        }
        

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Semi-resets the form when cancel is clicked
            lblError.Text = ""; //clear out error message(s)
            ClearFields(); //clear out all textbox fields
            ButtonsOn(); //turns on all buttons
            drpTechnician.Enabled = true; //re-enable drop down menu
            drpTechnician.SelectedValue = "0"; //make drop down menu default selection
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            DeleteTechnician(); //calls the DeleteTechnician function when Remove button is clicked
        }

        private void ClearFields()
        {
            //clears out all text boxes and places empty strings into each textbox
            txtFirstName.Text = String.Empty;
            txtMiddleInit.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtDepartment.Text = String.Empty;
            txtHourlyRate.Text = String.Empty;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (drpTechnician.SelectedValue != "0") //checks to see if selected value is of an existing employee or not
            {
                lblError.Text = "Cannot clear existing data"; //if employee is selected, will not clear out any data
            }
            else //if employee not selected clear out all fields
            {
                ClearFields(); //clear out all fields
            }
        }

        private void ButtonsOn() //turns on all buttons
        {
            btnAccept.Enabled = true;
            btnCancel.Enabled = true;
            btnRemove.Enabled = true;
            btnClear.Enabled = true;
            btnNewTechnician.Enabled = true;
        }

        protected void drpTechnician_SelectedIndexChanged(object sender, EventArgs e) //checks when drop down menu selection is changed
        {
            DisplayTechnician(drpTechnician.SelectedValue.ToString()); //fills in all textboxes with data that is selected in the drop down menu
            lblError.Text = ""; //clear out error text
        }
    }
}