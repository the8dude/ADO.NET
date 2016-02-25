using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DAO
{


    class ClientDAO
    {
        SqlConnection con;

        //Ouverture de la connexion au serveur SQL Hotel2
        public ClientDAO()
        {
            con = new SqlConnection("data source=.; initial catalog=hotel2; Trusted_Connection=true");
        }


        //Insertion de nouveaux clients
        public void Insert(Client cli)
        {

            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "INSERT into client (cli_nom, cli_prenom, cli_ville) values (@p1, @p2, @p3)";
            requete.Connection = con;
            requete.Parameters.AddWithValue("@p1", cli.cli_nom);
            requete.Parameters.AddWithValue("@p2", cli.cli_prenom);
            requete.Parameters.AddWithValue("@p3", cli.cli_ville);
            
            requete.ExecuteNonQuery();
            con.Close();
        }

        //Modification client déjà existant
        public void Update(Client cli)
        {
            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "UPDATE client SET cli_nom = @p1, cli_prenom = @p2, cli_ville = @p3 where cli_id = @p0 ";
            requete.Connection = con;
            requete.Parameters.AddWithValue("@p0", cli.cli_id);
            requete.Parameters.AddWithValue("@p1", cli.cli_nom);
            requete.Parameters.AddWithValue("@p2", cli.cli_prenom);
            requete.Parameters.AddWithValue("@p3", cli.cli_ville);

            requete.ExecuteNonQuery();
            con.Close();
        }

        //Suppression client déjà existant
        public void Delete(Client cli)
        {
            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "DELETE FROM client where cli_id = @p0 ";
            requete.Connection = con;
            requete.Parameters.AddWithValue("@p0", cli.cli_id);
            

            requete.ExecuteNonQuery();
            con.Close();
        }


        //Affichage de la liste des clients
        public List<Client> List()
        {
            List<Client> liste = new List<Client>();

            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "select * from client";
            requete.Connection = con;

            SqlDataReader resultat = requete.ExecuteReader();

            while (resultat.Read())
            {
                Client c = new Client();
                c.cli_id = Convert.ToInt32(resultat["cli_id"]);
                c.cli_nom = Convert.ToString(resultat["cli_nom"]);
                c.cli_prenom = Convert.ToString(resultat["cli_prenom"]);
                c.cli_ville = Convert.ToString(resultat["cli_ville"]);
                
                liste.Add(c);
            }
            resultat.Close();
            con.Close();
            return liste;
        }
    }
}