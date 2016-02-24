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
            con.Close();

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
            con = new SqlConnection("server = . ; database = papyrus ; integrated security = true;");

            //ouverture connexion
            con.Open();

            listBox1.Items.Clear();
            listBox1.Visible = true;
            label2.Visible = true;
            int i = 0;

            if (comboBox1.SelectedIndex == 1)
            {
                SqlCommand selectTous = new SqlCommand("select NUMCOM, OBSCOM, DATCOM from dude.ENTCOM join dude.FOURNIS on dude.FOURNIS.NUMFOU = dude.ENTCOM.NUMFOU", con);
                SqlDataReader execTous = selectTous.ExecuteReader();
                while (execTous.Read())
                {
                    listBox1.Items.Insert(i, execTous["NUMCOM"].ToString() + "  " + execTous["DATCOM"].ToString() + "  " + execTous["OBSCOM"].ToString());
                    i++;
                }
            }

            else
            {

                try
                {
                    SqlCommand search = new SqlCommand("exec GetEntCom '" + comboBox1.SelectedItem + "'", con);
                    SqlDataReader result = search.ExecuteReader();
                    
                    while (result.Read())
                    {
                        listBox1.Items.Insert(i, result["NUMCOM"].ToString() + "  " + result["DATCOM"].ToString() + "  " + result["OBSCOM"].ToString());
                        i++;
                    }

                    result.Close();

                }

                catch (Exception er)
                {
                    comboBox1.SelectedIndex = -1;
                    MessageBox.Show(er.Message);
                }

                finally
                {
                    con.Close();
                }
            }
            if (comboBox1.SelectedIndex == -1)
            {
                listBox1.Visible = false;
                label2.Visible = false;
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
