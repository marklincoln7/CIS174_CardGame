using System;

//Database access
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Card_Game_V002
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            //if server-side validation of proper entry
            if (Page.IsValid)
            {
                //Make an array of string values from user input in text boxes
                string[] txtVals = new string[] { txtBoxFName.Text, txtBoxLName.Text, txtBoxEmail.Text };

                //Create sql query command
                string cmdText = "INSERT INTO Members ([fName], [lName], [Email]) VALUES (@firstName, @lastName, @email)";

                //Create sql connection a https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.parameters(v=vs.110).aspx

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    SqlCommand cmd = new SqlCommand(cmdText, con);

                    //Add parameters to be included in the cmdText insert query string
                    cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = txtVals[(int)columns.fName];
                    cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = txtVals[(int)columns.lName];
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtVals[(int)columns.email];

                    try
                    {
                        //connect to database - open database and run query
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        //If error in try block display in custom validation (bottom of screen).
                        //CustomValidator1.ErrorMessage = ex.ToString();
                        //CustomValidator1.IsValid = false;
                    }
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            // Redirect user back to MainForm
            Response.Redirect("MainForm.aspx");
        }
    }
}