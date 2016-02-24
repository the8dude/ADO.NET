using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Exercice_4
{
    public partial class Form1 : Form
    {
        SqlConnection con;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

            try
            {
                SqlCommand requete = new SqlCommand(@"insert into dude.FOURNIS (NOMFOU, RUEFOU, POSFOU, VILFOU, CONFOU, SATISF) 
                                                values(@nomfou, @ruefou, @posfou, @vilfou, @confou, @satisf)", con);

                requete.Parameters.AddWithValue("@nomfou", textBox1.Text);
                requete.Parameters.AddWithValue("@ruefou", textBox2.Text);
                requete.Parameters.AddWithValue("@posfou", textBox3.Text);
                requete.Parameters.AddWithValue("@vilfou", textBox4.Text);
                requete.Parameters.AddWithValue("@confou", textBox5.Text);

                if (trackBar1.Value != 0)
                {
                    requete.Parameters.AddWithValue("@satisf", trackBar1.Value);
                }
                else
                {
                    requete.Parameters.AddWithValue("@satisf", DBNull.Value);
                }

                requete.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception er)
            {
                //MessageBox.Show("Une erreur de saisie s'est produite");
                er.Message.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show
                ("Fin de l’application ?", "FIN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }





        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Regex re_nom = new Regex(@"^[a-zA-Z]{1,25}$");
            if (re_nom.IsMatch(textBox1.Text))
            {
                textBox1.BackColor = Color.Green;
            }
            else
            {
                textBox1.BackColor = Color.Red;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Regex re_rue = new Regex(@"^[a-zA-Z]{1,50}$");
            if (re_rue.IsMatch(textBox2.Text))
            {
                textBox2.BackColor = Color.Green;
            }
            else
            {
                textBox2.BackColor = Color.Red;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Regex re_cp = new Regex(@"^[0-9][0-9][0-9][0-9][0-9]$");
            if (re_cp.IsMatch(textBox3.Text))
            {
                textBox3.BackColor = Color.Green;
            }
            else
            {
                textBox3.BackColor = Color.Red;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Regex re_vil = new Regex(@"^[a-zA-Z]{1,30}$");
            if (re_vil.IsMatch(textBox4.Text))
            {
                textBox4.BackColor = Color.Green;
            }
            else
            {
                textBox4.BackColor = Color.Red;
            }
        }
    }
}
