using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Opdracht1
{
    public partial class NieuwPersoneel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Maak het database-object
            Database dbase = new Database();

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

            //Maak een nieuw lid aan
            dbase.toevoegen(gegevens);

            //Stuur de gebruiker terug naar de home pagina
            Response.Redirect("Default.aspx");
        }
    }
}