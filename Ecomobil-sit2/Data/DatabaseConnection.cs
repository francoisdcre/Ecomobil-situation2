using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Ecomobil_sit2.Data
{
    internal class DatabaseConnection
    {
        // Informations sur la connexion
        string connectionString = "server=localhost;user=root;database=ecomobil;port=3306;password=;";
        // Commande SQL d'exemple
        string query = "SELECT * FROM agences";

        // Test de connexion et affichage du résultat
        public DatabaseConnection()
        {
            // Utilisation d'un StringBuilder pour accumuler le résultat
            StringBuilder result = new StringBuilder();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Ouvrir la connexion
                    connection.Open();

                    // Créer une commande MySQL
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // Exécuter la commande et lire les données
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Lire les données ligne par ligne
                        while (reader.Read())
                        {
                            result.AppendLine($"Nom de l'agence : {reader["nom"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.AppendLine($"Erreur : {ex.Message}");
                }
            }

            // Afficher le résultat dans une MessageBox (affiché dans la fenêtre WPF)
            MessageBox.Show(result.ToString(), "Résultat de la connexion");
        }
    }
}