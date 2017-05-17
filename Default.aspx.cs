using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Opdracht1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Maak het Database object
            Database dbase = new Database();

            //Lees alle personeelsleden
            DataTable dt = dbase.getAllPersoneelDT();

            //Koppel de DataTable aan de GridView
            personeelslijst.DataSource = dt;
            personeelslijst.DataBind();
        }
    }
}