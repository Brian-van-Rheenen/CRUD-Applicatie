using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Opdracht1
{
    public partial class DeletePersoneel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Maak het database-object
            Database dbase = new Database();

            //Lees het ID uit de URL
            string ID = Request.QueryString["ID"];

            //Verwijder de gegevens
            dbase.verwijderen(ID);

            //Stuur de gebruiker terug naar de home pagina
            Response.Redirect("Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Stuur de gebruiker terug naar de home pagina
            Response.Redirect("Default.aspx");
        }
    }
}