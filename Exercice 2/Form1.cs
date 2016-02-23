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

namespace Exercice_2
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataReader result;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

                //creation commande
                SqlCommand search = new SqlCommand("select * from dude.FOURNIS where NUMFOU =" + textBox1.Text, con);

                result = search.ExecuteReader();

                
                while (result.Read())
                {
                    textBox2.Text = result["NOMFOU"].ToString();
                    textBox3.Text = result["RUEFOU"].ToString();
                    textBox4.Text = result["POSFOU"].ToString();
                    textBox5.Text = result["VILFOU"].ToString();
                    textBox6.Text = result["CONFOU"].ToString();
                }

                result.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Cette requête ne peut aboutir");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
