using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Opdracht1
{
    public partial class EditPersoneel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Lees het ID uit de URL
                String ID = Request.QueryString["ID"];

                //Maak het database-object
                Database dbase = new Database();

                //Lees de gevraagde persoon uit de database
                ArrayList persoon = dbase.getPersoonAL(ID);

                //Schrijf de tekstvelden in het formulier
                TextBoxVoornaam.Text = persoon[1].ToString();
                TextBoxAchternaam.Text = persoon[2].ToString();

                //Stel de radio in in het formulier
                if (persoon[4].ToString() == "M")
                {
                    Geslacht.Items[0].Selected = true;
                }
                else if (persoon[4].ToString() == "V")
                {
                    Geslacht.Items[1].Selected = true;
                }

                //Stel de Calendar in in het formulier
                string geborenText = persoon[3].ToString();
                DateTime geboren = DateTime.Parse(geborenText);
                CalendarGeboren.SelectedDate = geboren;
                CalendarGeboren.VisibleDate = geboren;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Maak het database-object
            Database dbase = new Database();

            //Lees het ID uit de URL
            string ID = Request.QueryString["ID"];

            //Lees het formulier uit
            string voornaamText = TextBoxVoornaam.Text;
            string AchternaamText = TextBoxAchternaam.Text;
            DateTime geboren = CalendarGeboren.SelectedDate;
            string geborenText = geboren.ToString("yyyy-MM-dd");
            string geslacht = Geslacht.SelectedItem.ToString();

            //Maak een lege ArrayList en vul die met de gegevens
            ArrayList gegevens = new ArrayList();
            gegevens.Add(voornaamText);
            gegevens.Add(AchternaamText);
            gegevens.Add(geborenText);
            gegevens.Add(geslacht);

            //Update de gegevens
            dbase.updaten(gegevens, ID);

            //Stuur de gebruiker terug naar de home pagina
            Response.Redirect("Default.aspx");
        }
    }
}