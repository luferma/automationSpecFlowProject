using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace TaxChatTAFSpecFlow.utils
{
    class ConnectionMySql
    {
        public static void ConnectMySqlDataBase(string email)
        {           
            MySqlConnection cnn;            
            string connetionString = "server=acusnpqtxcsql01.mysql.database.azure.com;database=taxchat;uid=tcadm@acusnpqtxcsql01;pwd=fhQR5JExC4iQJImxDHqZ7xDQtfhWmFd;Port=3306;Connection Timeout=360";            
            
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();

                string sqlSelectStatus = "SELECT id from background_check_status where name = 'Accepted'";
                var cmdSelect = new MySqlCommand(sqlSelectStatus, cnn);
                MySqlDataReader readerStatus = cmdSelect.ExecuteReader();
                int codeAccepted = 0;
                if (readerStatus.Read())
                {
                    codeAccepted = readerStatus.GetInt32(0);
                }
                cnn.Close();
                cnn.Open();

                string sqlUpdate = "UPDATE tax_return AS tr, participant AS part SET tr.background_check_status_id = '" + codeAccepted + "', tr.on_hold='0' " +
                    "WHERE tr.participant_id = part.id AND part.email = '" + email + "'";
                var cmdUpdate = new MySqlCommand(sqlUpdate, cnn);
                cmdUpdate.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", "Connection Error" + ex.Message);                               
            }
            finally
            {
                cnn.Close();
            }
        }

        public static string GetAnswerQuestionHowDidYou(string email)
        {
            MySqlConnection cnn;
            string connetionString = "server=acusnpqtxcsql01.mysql.database.azure.com;database=taxchat;uid=tcadm@acusnpqtxcsql01;pwd=fhQR5JExC4iQJImxDHqZ7xDQtfhWmFd;Port=3306;Connection Timeout=360";
            cnn = new MySqlConnection(connetionString);
            string text = "";

            try
            {
                cnn.Open();
                
                string sqlUpdate = "select participant.how_do_you_hear_about_text from participant where email = '" + email + "'";
                var cmdSelect = new MySqlCommand(sqlUpdate, cnn);
                MySqlDataReader readerStatus = cmdSelect.ExecuteReader();                
                if (readerStatus.Read())
                {
                    text = readerStatus.GetString(0);
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", "Connection Error" + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return text;
        }
    }
}
