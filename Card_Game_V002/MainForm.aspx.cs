using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Joey_Wilhelms_Project_Membership
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            //Session state pull to access potential game from data base (suggestion here)

            //redirected to cart form

            Response.Redirect("~/Cart.aspx");
        }
    }
}