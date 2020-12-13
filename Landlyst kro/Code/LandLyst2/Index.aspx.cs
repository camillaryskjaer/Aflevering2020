using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace LandLyst2
{
    public partial class Index : System.Web.UI.Page
    {
        //connection string
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-8KCM6EA;Initial Catalog=LandLyst_Kro;"
        + "Integrated Security=true;");

        //submit request to book a room.
        //calls the stored procedure called Submitrequest, which inserts the data filled out in the form into customers table and request table.

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand("SubmitRequest", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //This code is just to allow user to enter their full name on one line, then it splits it itself for the database
                //--
                string[] name = txtFullName.Text.Split(' ');

                sqlCmd.Parameters.AddWithValue(@"FirstName", name[0]);

                if (name.Count() > 1)
                {
                    string middleName = "";
                    int i = 1;
                    while (name[i] != name.Last())
                    {
                        middleName += name[i] + " ";
                        i++;
                    }
                    sqlCmd.Parameters.AddWithValue(@"MiddleName", middleName.Trim());
                    sqlCmd.Parameters.AddWithValue(@"LastName", name.Last());
                }
                else
                {
                    sqlCmd.Parameters.AddWithValue(@"MiddleName", "");
                    sqlCmd.Parameters.AddWithValue(@"LastName", "");
                }
                //--

                sqlCmd.Parameters.AddWithValue(@"PhoneNumber", txtPhoneNumber.Text.Trim());
                sqlCmd.Parameters.AddWithValue(@"Email", txtEmail.Text.Trim());
                sqlCmd.Parameters.AddWithValue(@"OrderDate", DateTime.Now);
                sqlCmd.Parameters.AddWithValue(@"CheckInDate", Convert.ToDateTime(txtCheckIn.Text));
                sqlCmd.Parameters.AddWithValue(@"CheckOutDate", Convert.ToDateTime(txtCheckOut.Text));
                //If nothing has been changed in the addition information message, then send a blank string to the database
                if (txtOrderDetails.Text == "If there is something else you want to let us know type it here")
                {
                    sqlCmd.Parameters.AddWithValue(@"OrderDetails", "");

                }
                else
                {
                    sqlCmd.Parameters.AddWithValue(@"OrderDetails", txtOrderDetails.Text.Trim());
                }

                string attributes = "";

                //store requested attributes as 1s and 0s.
                for (int x = 0; x < extra.Items.Count; x++)
                {
                    if (extra.Items[x].Selected)
                    {
                        attributes += "1";
                    }
                    else
                    {
                        attributes += "0";
                    }
                }

                sqlCmd.Parameters.AddWithValue(@"RequestedAttributes", attributes);

                sqlCmd.ExecuteNonQuery();
                Clear();
                lblSuccessMessage.Text = "Submitted successfully";

        }

        //clears the form, ready for another request :)
        void Clear()
        {
            txtFullName.Text = txtPhoneNumber.Text = txtEmail.Text = "";
            txtOrderDetails.Text = "If there is something else you want to let us know type it here";
            txtCheckIn.Text  = DateTime.Now.ToShortDateString();
            txtCheckOut.Text = DateTime.Now.ToShortDateString();
            lblSuccessMessage.Text = "";
            extra.ClearSelection();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCheckOut.Text = DateTime.Today.ToShortDateString();
                txtCheckIn.Text = DateTime.Today.ToShortDateString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }


        //calculates the cost of extra attributes the customer has selected for their room and multiply it by the amount of days they wish to stay.
        protected void CalculatePrice_Click(object sender, EventArgs e)
        {
            int totalPrice = 695;

            for (int i = 0; i < extra.Items.Count; i++)
            {
                if (extra.Items[i].Selected)
                {
                    totalPrice = totalPrice + Convert.ToInt32(extra.Items[i].Value);
                }
            }
            
            
            int days = Convert.ToInt32((Convert.ToDateTime(txtCheckOut.Text) - Convert.ToDateTime(txtCheckIn.Text)).TotalDays.ToString());

            totalPrice = (totalPrice * days);

            if (days >= 7)
            {
                totalPrice = Convert.ToInt32(Math.Round(totalPrice * 0.9));
            }

            txtPrice.Text = totalPrice.ToString();
        }

        protected void extra_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtCheckIn_Click(object sender, EventArgs e)
        {
            txtCheckIn.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void txtCheckOut_Click(object sender, EventArgs e)
        {
            txtCheckOut.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        
    }
}