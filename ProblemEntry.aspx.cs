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
    public partial class ProblemEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //check if page is being loaded for the first time or is responding to a postback
            {
                lblError.Text = ""; //clear out error text
                LoadTechnicians(); //load all technicians into the application
                LoadProducts(); //load all products into the application
                
            }
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



        private void LoadProducts() //loads technicians into the applications
        {
            DataSet dsData; //create dataset

            dsData = clsDatabase.GetProductList(); //attribute dataset to the GetTechnicianList database stored procedure
            if (dsData == null) //if dataset was null, show error message
            {
                lblError.Text = "Error retrieving Product list";
            }
            else if (dsData.Tables.Count < 1) //check if there are any tables
            {
                lblError.Text = "Error retrieving Product list"; //show error message
                dsData.Dispose(); //dispose of dataset
            }
            else //if dataset is not null and was successful, get technician list
            {
                drpProduct.AppendDataBoundItems = true; //allows to add a new item into dropdown list
                drpProduct.Items.Clear(); //clear items
                drpProduct.DataSource = dsData.Tables[0]; //where we get our data from
                drpProduct.DataTextField = "ProductDesc"; //the full name of the technician is what we will see in the drop down menu as options
                drpProduct.DataValueField = "ProductID"; //the techID is what the drop down list will be sorted by
                drpProduct.Items.Add(new ListItem("-- Select Product --", "0")); //create new list item, this will be the default one shown when application is loaded
                drpProduct.DataBind(); //bind data in order that it all is connected and functions correctly

                dsData.Dispose(); //dispose of dataset
            }
        }

        private void ValidateFields()
        {
            Boolean blnOk = true; //create and set boolean to true
            lblError.Text = ""; //clear out error label

            if (drpProduct.SelectedValue == "0")
            {
                blnOk = false; //set boolean to false
                if (String.IsNullOrWhiteSpace(lblError.Text))
                {
                    lblError.Text = "Product must be selected";
                }
                else
                {
                    lblError.Text += ", Product must be selected";
                }
            }
            
            if (String.IsNullOrWhiteSpace(txtProblem.Text))
            {
                blnOk = false; //set boolean to false due to error
                if (String.IsNullOrWhiteSpace(lblError.Text))
                {
                    lblError.Text = "Problem description cannot be empty";
                }
                else
                {
                    lblError.Text += ", Problem description cannot be empty";
                }
            }

            if (drpTechnician.SelectedValue == "0")
            {
                blnOk = false; //set boolean to false due to error
                if (String.IsNullOrWhiteSpace(lblError.Text))
                {
                    lblError.Text = "Technician must be selected";
                }
                else
                {
                    lblError.Text += ", Technician must be selected";
                }
            }
            
        }

        protected void btnService_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceEvent.aspx"); //redirects back to Service Event page
        }

        private void ClearFields()
        {
            lblError.Text = "";
            txtProblem.Text = String.Empty;
            drpProduct.SelectedValue = "0";
            drpTechnician.SelectedValue = "0";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields(); //clear out error labels, text fields, and set drop downs to default
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ValidateFields(); //make sure all fields and information there of are valid
        }
    }
}