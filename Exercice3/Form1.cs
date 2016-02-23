using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Exercice3
{
    public partial class Form1 : Form
    {
        SqlConnection con;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Tous");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //creation connexion
            con = new SqlConnection("server = . ; database = papyrus ; integrated security = true;");
            try
            {
                //ouverture connexion
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de connexion, vérifiez l'existence de la base de donnée");
            }

            SqlCommand liste = new SqlCommand("select * from dude.FOURNIS", con);

            SqlDataReader result = liste.ExecuteReader();


            while (result.Read())
            {
                comboBox1.Items.Add(result["NOMFOU"]);
            }

            result.Close();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show
                ("Fin de l’application ?", "FIN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



















        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
