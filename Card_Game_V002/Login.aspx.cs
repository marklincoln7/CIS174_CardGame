using System;

//Database access
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Joey_Wilhelms_Project_Membership
{
    public partial class Login : System.Web.UI.Page
    {
        const byte COLUMNS = 2;
        enum dbColumns : byte { email = 0, password };

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            txtBoxEmail.Focus();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //move to Membership page to store user information in database <jcw>
            Response.Redirect("~/Membership.aspx");
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //hide login error if page is valid
                string passwordText = "";
                //if the password matches the encrypted values of the database
                Decrypt(txtBoxPassword.Text, out passwordText);

                //Make an array of string values from user input in text box and encryted value <jcw>
                string[] txtVals = new string[] { txtBoxEmail.Text, passwordText };

                //Create sql query command to search for membership <jcw>
                string cmdText = "SELECT [Email], [Password] FROM Members WHERE ([Email] = @email AND [Password] = @password)";

                //Create sql connection a https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.parameters(v=vs.110).aspx <jcw>

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        //Add parameters to be included in the cmdText insert query string <jcw>
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtVals[(int)dbColumns.email];
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtVals[(int)dbColumns.password];
                        //connect to database - open database and run query <jcw>
                        cmd.Connection = con;
                        con.Open();
                        //https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqldatareader(v=vs.110).aspx <jcw>
                        //will be destroyed after using reader...<jcw>
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            if (dataReader.HasRows)//check if database has rows to read <jcw>
                            {
                                while (dataReader.Read()) //read until match is found<jcw>
                                {
                                    //Pass userName value as session to next form for use in main form. <jcw>
                                    Session.Add("userName", txtBoxEmail.Text);
                                    Response.Redirect("~/MainForm.aspx");
                                }
                            }
                            else
                            {
                                lblLoginError.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        protected void custValLogin_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !(txtBoxEmail.Text == string.Empty) ? true : false;
        }

        //val passed is txtBoxPassword.text out is encrypted value <jcw>
        protected string Decrypt(string val, out string encVal)
        {
            string tmp = "";
            //char size key for encrypting in hex <jcw>
            byte encKey = 65;
            for (int i = 0; i < val.Length; i++)
            {
                //create tmp string that stored xor shifted characters from 
                //original password value http://www.cplusplus.com/forum/articles/38516/ <jcw>
                tmp += val[i] ^ (((int)(encKey) + i) % 239);
            }
            encVal = tmp;
            return encVal;
        }
    }
}
