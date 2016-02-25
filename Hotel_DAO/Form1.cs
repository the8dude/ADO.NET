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

namespace Hotel_DAO
{
    public partial class Form1 : Form
    {
        string action;
        int id_client;

        public Form1()
        {
            InitializeComponent();
        }

        //Button 6 : Chargement de la liste des clients
        private void button6_Click(object sender, EventArgs e)
        {
            Width = 760;
            ClientDAO hotel2 = new ClientDAO();

            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = hotel2.List();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        //Button4 : Gestion Client DB Hotel2
        private void button4_Click(object sender, EventArgs e)
        {

            //-------------------------Ajout Nouveau Client
            if (action == "ajouter")
            {
                Client c = new Client();
                c.cli_nom = textBox1.Text;
                c.cli_prenom = textBox2.Text;
                c.cli_ville = textBox3.Text;

                ClientDAO hotel2 = new ClientDAO();

                DialogResult dr = MessageBox.Show
                   ("Souhaitez-vous ajouter ce nouveau client ?", "Ajout nouveau client", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    hotel2.Insert(c);

                    //Refresh DataGriedView
                    hotel2 = new ClientDAO();

                    dataGridView1.ReadOnly = true;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.DataSource = hotel2.List();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    groupBox1.Enabled = false;

                }

            }

            //-------------------------Modifier Client
            if (action == "modifier")
            {
                Client c = new Client();


                c.cli_nom = textBox1.Text;
                c.cli_prenom = textBox2.Text;
                c.cli_ville = textBox3.Text;
                c.cli_id = id_client;
                

                ClientDAO hotel2 = new ClientDAO();

                DialogResult dr = MessageBox.Show
                   ("Souhaitez-vous modifier le client existant ?", "Modifier client existant", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    hotel2.Update(c);

                    //Refresh DataGriedView
                    hotel2 = new ClientDAO();

                    dataGridView1.ReadOnly = true;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.DataSource = hotel2.List();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    groupBox1.Enabled = false;

                }
            }

            //-------------------------Supprimer Client
            if (action == "supprimer")
            {
                Client c = new Client();
                c.cli_nom = textBox1.Text;
                c.cli_prenom = textBox2.Text;
                c.cli_ville = textBox3.Text;
                c.cli_id = id_client;


                ClientDAO hotel2 = new ClientDAO();

                DialogResult dr = MessageBox.Show
                   ("Souhaitez-vous supprimer le client existant ?", "Supprimer client existant", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    hotel2.Delete(c);

                    //Refresh DataGriedView
                    hotel2 = new ClientDAO();

                    dataGridView1.ReadOnly = true;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.DataSource = hotel2.List();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    groupBox1.Enabled = false;

                }
            }
        }

        //Button5 : Annuler la saisie
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show
                   ("Souhaitez-vous annuler la saisie du nouveau client ?", "Ajout nouveau client", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                groupBox1.Enabled = false;
            }
        }
        //Textbox3 : cli_nom
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Regex re_cli_nom = new Regex(@"^[a-zA-Z ']{1,50}$");

            if (textBox1.Text.Length != 0)
            {
                if (re_cli_nom.IsMatch(textBox1.Text))
                {
                    textBox1.BackColor = Color.Green;
                }
                else
                {
                    textBox1.BackColor = Color.Red;

                }
            }
            else
            {
                textBox1.BackColor = SystemColors.Window;
            }
        }

        // Textbox2 : cli_prenom
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Regex re_cli_prenom = new Regex(@"^[a-zA-Z 'éè]{1,50}$");

            if (textBox2.Text.Length != 0)
            {
                if (re_cli_prenom.IsMatch(textBox2.Text))
                {
                    textBox2.BackColor = Color.Green;
                }
                else
                {
                    textBox2.BackColor = Color.Red;

                }
            }
            else
            {
                textBox2.BackColor = SystemColors.Window;
            }
        }

        // Textbox3 : cli_ville
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Regex re_cli_ville = new Regex(@"^[a-zA-Z -]{1,50}$");

            if (textBox3.Text.Length != 0)
            {
                if (re_cli_ville.IsMatch(textBox3.Text))
                {
                    textBox3.BackColor = Color.Green;
                }
                else
                {
                    textBox3.BackColor = Color.Red;

                }
            }
            else
            {
                textBox3.BackColor = SystemColors.Window;
            }
        }

        //Button1 : Ajout nouveau client
        private void button1_Click(object sender, EventArgs e)
        {
            Width = 760;

            groupBox1.Enabled = true;
            action = "ajouter";

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();


        }

        //Button1 : Modif client
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            action = "modifier";

            if (dataGridView1.SelectedRows.Count != -1)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                id_client = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        //Button1 : Suppr client
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            action = "supprimer";
            if (dataGridView1.SelectedRows.Count != -1)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                id_client = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 512;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show
                   ("Souhaitez-vous quitter l'application ?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();

            }

        }


        private void dataGridView1_MultiSelectChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
