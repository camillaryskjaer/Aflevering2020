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
    public partial class ManageRequests : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-8KCM6EA;Initial Catalog=LandLyst_Kro;"
        + "Integrated Security=true;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                deleteButton.Enabled = false;
                FillGridView();
            }
        }

        protected void txtOrderDate_Click(object sender, EventArgs e)
        {

        }

        protected void txtOrderDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }


        public void Clear()
        {
            hfRequestID.Value = "";
            txtRequester.Text = txtPhoneNumber.Text = txtEmail.Text =  txtOrderDetails.Text = txtRequestedAttributes.Text 
            = txtRoomNumber.Text = "";
            txtCheckInDate.Text = txtCheckOutDate.Text = txtOrderDate.Text = "";
            lblErrorMessage.Text = lblSuccessMessage.Text = "";
            deleteButton.Enabled = false;
        }

        protected void @false(object sender, EventArgs e)
        {

        }

        

        protected void gvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            if(sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("RequestUpdateOrDelete", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                string[] Name = NameSplitter();
                sqlCmd.Parameters.AddWithValue("@FirstName", Name[0]);
                sqlCmd.Parameters.AddWithValue("@MiddleName", Name[1]);
                sqlCmd.Parameters.AddWithValue("@LastName", Name[2]);
                sqlCmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                //room attributes
                //wierdly formatted, but wouldve been very long otherwise
                //simply converts the array of reqeusted attribtes to their respective attributes in text, and then puts them into the field so it is readable.
                string RA = "";
                if (txtRequestedAttributes.Text.Contains("Balcony")) { RA += "1"; } else { RA += "0"; }
                if (txtRequestedAttributes.Text.Contains("Jacuzzi")) { RA += "1"; } else { RA += "0"; }
                if (txtRequestedAttributes.Text.Contains("Bathtub")) { RA += "1"; } else { RA += "0"; }
                if (txtRequestedAttributes.Text.Contains("Double Bed")) { RA += "1"; } else { RA += "0"; }
                if (txtRequestedAttributes.Text.Contains("Kitchen")) { RA += "1"; } else { RA += "0"; }
                sqlCmd.Parameters.AddWithValue("@RequestedAttributes", RA);

                sqlCmd.Parameters.AddWithValue("@OrderDate ", Convert.ToDateTime(txtOrderDate.Text));
                sqlCmd.Parameters.AddWithValue("@CheckInDate", Convert.ToDateTime(txtCheckInDate.Text));
                sqlCmd.Parameters.AddWithValue("@CheckOutDate", Convert.ToDateTime(txtCheckOutDate.Text));
                sqlCmd.Parameters.AddWithValue("@OrderDetails", txtOrderDetails.Text.Trim());
                sqlCmd.ExecuteNonQuery();

                //if there's text in roomnumber, execute the proc bookroom which inserts data into RoomRequests of booked rooms.
                if(txtRoomNumber.Text != "")
                {
                    SqlCommand sqlCmd2 = new SqlCommand("BookRoom", sqlCon);
                    sqlCmd2.CommandType = CommandType.StoredProcedure;
                    sqlCmd2.Parameters.AddWithValue("@RoomNumber", Convert.ToInt32(txtRoomNumber.Text));
                    sqlCmd2.Parameters.AddWithValue("@RequestID", Convert.ToInt32(hfRequestID.Value));
                    sqlCmd2.ExecuteNonQuery();
                }

                sqlCon.Close();

                Clear();
                lblSuccessMessage.Text = "Updated Successfully";
                FillGridView();
            }
        }

        void FillGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ViewAll", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                sqlCon.Close();
                gvRequests.DataSource = dtbl;
                gvRequests.DataBind();
            }
        }

        string[] NameSplitter()
        {
            string[] splitName = new string[3];

            string[] name = txtRequester.Text.Split(' ');

            splitName[0] = name[0] + " "; 

            if (name.Count() > 1)
            {
                string middleName = "";
                int i = 1;
                while (name[i] != name.Last())
                {
                    middleName += name[i] + " ";
                    i++;
                }
                splitName[1] = middleName;
                splitName[2] = name.Last();
            }
            else
            {
                splitName[1] = "";
                splitName[2] = "";

            }

            return splitName;
        }

        //shows all the data from the selected request from the grid
        protected void lnk_OnClick(object sender, EventArgs e)
        {
            int requestID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ViewByRequestID", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("RequestID", requestID);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                sqlCon.Close();
                hfRequestID.Value = requestID.ToString();
                string name = dtbl.Rows[0]["FirstName"].ToString() + dtbl.Rows[0]["MiddleName"].ToString() + dtbl.Rows[0]["LastName"].ToString();
                txtRequester.Text = name;
                txtPhoneNumber.Text = dtbl.Rows[0]["PhoneNumber"].ToString();
                txtEmail.Text = dtbl.Rows[0]["Email"].ToString();
                txtOrderDate.Text = dtbl.Rows[0]["RequestDate"].ToString();
                txtCheckInDate.Text = dtbl.Rows[0]["CheckInDate"].ToString();
                txtCheckOutDate.Text = dtbl.Rows[0]["CheckOutDate"].ToString();

                string extra = "";
                char[] attributes = dtbl.Rows[0]["RequestedAttributes"].ToString().ToCharArray();
                if (attributes[0].ToString() == "1")
                {
                    extra += "Balcony "; 
                }
                if (attributes[1].ToString() == "1")
                {
                    extra += "Jacuzzi ";
                }
                if (attributes[2].ToString() == "1")
                {
                    extra += "Bathtub ";
                }
                if (attributes[3].ToString() == "1")
                {
                    extra += "Double Bed ";
                }
                if (attributes[4].ToString() == "1")
                {
                    extra += "Kitchen ";
                }
                txtRequestedAttributes.Text = extra.Trim();

                txtOrderDetails.Text = dtbl.Rows[0]["RequestInformation"].ToString();
                deleteButton.Enabled = true;
            }
        }

        //executes the stored procedure which deletes a request and the customer assosiated with it.
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("DeleteByRequestID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RequestID", Convert.ToInt32(hfRequestID.Value));
                sqlCmd.Parameters.AddWithValue("@Contact", txtPhoneNumber.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                Clear();
                FillGridView();
                lblSuccessMessage.Text = "Deleted Successfully";
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}