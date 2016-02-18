using System;
using System.Configuration;
using System.Data;
//Using link to remedy tab control
using System.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Joey_Wilhelms_Project_Membership
{
    public partial class Membership : System.Web.UI.Page
    {
        const byte PASSWORD_STRENGTH = 3;
        enum columns { fName, lName, email, password };
        enum passwordVals { length = 0, lower, upper, digit, symbol };
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Page.IsPostBack)
            {
                http://stackoverflow.com/questions/6016374/how-to-maintain-tab-order-after-postback
                //using linq to find web control that caused post back and set focus (copy paste method fix from stackoverflow)
                //DO NOT REMOVE THIS LINK <jcw>
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }
            else
            {
                txtBoxFName.Focus();
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            //if server-side validation of proper entry
            
            if (Page.IsValid)
            {
                //Hide Warning label <jcw>
                lblWarningDatabase.Visible = false;
                string passwordText = "";
                //Encrypt password value
                Encrypt(txtBoxPassword.Text, out passwordText);
                
                //Make an array of string values from user input in text boxes and encrypted password
                string[] txtVals = new string[] { txtBoxFName.Text, txtBoxLName.Text, txtBoxEmail.Text,
                                              passwordText};

                //Create sql query command
                string cmdText = "INSERT INTO Members ([fName], [lName], [Email], [Password]) VALUES (@firstName, @lastName, @email, @password)";

                //Create sql connection a https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.parameters(v=vs.110).aspx

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        //Add parameters to be included in the cmdText insert query string
                        cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = txtVals[(int)columns.fName];
                        cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = txtVals[(int)columns.lName];
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtVals[(int)columns.email];
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtVals[(int)columns.password];

                        //connect to database - open database and run query
                        try
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            lblWarningDatabase.Text = ex.Message;
                        }  
                    }
                }
                //on success - return to the login page -- this may be changed to the main interface page <jcw>
                Response.Redirect("~/MainForm.aspx");
            }
        }

        //val passed is txtBoxPassword.text out is encrypted value <jcw>
        protected string Encrypt(string val, out string encVal)
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
        protected void custValDuplicateEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                //Creates a new connection to the Members database and a command to count the number of records with an identical email
                SqlConnection membersConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand("Select count(*) from Members where Email=@Email", membersConn);

                //Add this parameter to the query
                myCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtBoxEmail.Text;

                //Opens the connection, checks for the number of records that match, then closes the connection
                membersConn.Open();
                int numMatches = Convert.ToInt32(myCommand.ExecuteScalar().ToString());
                membersConn.Close();

                //If a match is returned, there is a duplicate key and validation fails
                if (numMatches > 0)
                {
                    //Display error showing that email address is already in use <jcw>
                    args.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                //For testing
                lblWarningDatabase.Text = ex.Message;
                lblWarningDatabase.Visible = true;
                //If an exception is thrown, do not validate the email
                args.IsValid = false;
            }
        }
        /*
         *  Called by a custom validator to check if the password entered is valid.
         */
        protected void CustValPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //Adaptation of below commented code in order to allow for possible animated 
            //progress bar (increased by passwordStrength variable) <jcw>
            string val = txtBoxPassword.Text;
            byte passwordStrength = 0;
            bool[] password = new bool[] { false, false, false, false };

            //make sure the length of the password is atleast 8 keys
            if (val.Length > 7)
            {   //automatic strength to the password and allow the password to pass checking for the below characters
                passwordStrength++;

                foreach (char c in val)
                {//test each character of a string for certain keys - upper, lower, digit, symbol - add password strength if true  reset the loop
                 //if these values are found and go to the next character of the string. add password strength if the "if" statement passes
                    if (char.IsUpper(c) && !password[(int)passwordVals.upper]) { password[(int)passwordVals.upper] = true; passwordStrength++; continue; }

                    if (char.IsLower(c) && !password[(int)passwordVals.lower]) { password[(int)passwordVals.lower] = true; passwordStrength++; continue; }

                    if (char.IsDigit(c) && !password[(int)passwordVals.digit]) { password[(int)passwordVals.digit] = true; passwordStrength++; continue; }

                    if (char.IsSymbol(c) && !password[(int)passwordVals.symbol]) { password[(int)passwordVals.symbol] = true; passwordStrength++; continue; }
                }
            }
            //validation is dependant of password strength - if it contains 3 of the items it is strong enough.
            args.IsValid = (passwordStrength > PASSWORD_STRENGTH) ? true : false;
        }

        /*Required Serverside Validators*/

        protected void custValFName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //is valid set to false if string is empty
            args.IsValid = ((txtBoxFName.Text == string.Empty) ? false : true);
        }

        protected void custValLName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //is valid set to false if string is empty
            args.IsValid = ((txtBoxLName.Text == string.Empty) ? false : true);
        }

        protected void custValEmail_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            //is valid set to false if string is empty
            args.IsValid = ((txtBoxEmail.Text == string.Empty) ? false : true);
        }

        protected void txtBoxFName_TextChanged(object sender, EventArgs e)
        {
            //set is valid field based on NamePass method
            regexValFName.IsValid = NamePass(sender);
        }

        protected void txtBoxLName_TextChanged(object sender, EventArgs e)
        {
            regexValLName.IsValid = NamePass(sender);
        }

        protected bool NamePass(object obj)
        {
            TextBox txtBox = (TextBox)obj;
           
            bool pass = true;
            //test if the value is a letter and return bool
            foreach(char c in txtBox.Text)
            {
                if (char.IsLetter(c) == false)
                {
                    pass = false;
                    break;
                }
                
            }
            return pass;    
        }

        //This method retrieves the control that caused postback (this is a copy paste fix from stackoverflow)
        //http://stackoverflow.com/questions/6016374/how-to-maintain-tab-order-after-postback
        protected Control GetControlThatCausedPostBack(Page page)
        {
            Control control = null;
            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }
            }
                return control;
        }
    }
}








/*adaptations in code Password used in the CustValPassword_ServerValidate method
 //Must be between 8-20 characters
            const int MIN_LENGTH = 8;
//removed MAX_LENGTH as implied by limiting text box to 20 characters <jcw>
//Must have an uppercase letter, a lowercase letter, a number, a symbol or punctuation character, and
//  not contain any white space
bool meetsLengthRequirements = txtBoxPassword.Text.Length >= MIN_LENGTH;
bool hasUpperCaseLetter = false;
bool hasLowerCaseLetter = false;
bool hasNumber = false;
bool hasSpecialCharacter = false;
bool hasWhiteSpace = false;

            //If it meets the length requirements
            if (meetsLengthRequirements)
            {
               
                
                
                 //Check for the necessary characters and lack of white space
                foreach (char c in txtBoxPassword.Text)
                {
                    if (char.IsUpper(c))
                    {
                        hasUpperCaseLetter = true;
                    }
                    else if (char.IsLower(c))
                    {
                        hasLowerCaseLetter = true;
                    }
                    else if (char.IsNumber(c))
                    {
                        hasNumber = true;
                    }
                    else if (char.IsPunctuation(c) || char.IsSymbol(c))
                    {
                        hasSpecialCharacter = true;
                    }
                    else if (char.IsWhiteSpace(c))
                    {
                        hasWhiteSpace = true;
                    }
                }
            }

            //If it passes all the requirements, validation is successful. If not, it fails.
            if (meetsLengthRequirements && hasUpperCaseLetter && hasLowerCaseLetter &&
                hasNumber && hasSpecialCharacter && !hasWhiteSpace)
            {
                args.IsValid = true;
            }
            else
            {
                //Display password formatting error <jcw>

                args.IsValid = false;
            }
    */

    //Set type of text box to email for auto test do not need this code.
/*
protected void CustValEmail_ServerValidate(object source, ServerValidateEventArgs args)
{
    //If the text box is not empty or filled with only white space...
    if (!String.IsNullOrWhiteSpace(txtBoxEmail.Text))
    {
        try
        {
            //Test if the email is in valid format
            if (Regex.IsMatch(txtBoxEmail.Text,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                //If yes, then it passes server validation
                args.IsValid = true;
            }
        }
        catch (Exception ex)
        {

        }
    }
}*/
