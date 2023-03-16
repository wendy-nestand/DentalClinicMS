using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace DjunPro
{
    
    // Utils class to hash the password and put the slot time in a dictionnary structure
    public static class Utils
    {
        

        public static string hashPass(string password)
        {

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] password_bytes = Encoding.ASCII.GetBytes(password);
            byte[] encrypted_bytes = sha1.ComputeHash(password_bytes);
            return Convert.ToBase64String(encrypted_bytes);
        }

        public static Dictionary<int, string> getSlots()
        {
            string place = " Place";
            Dictionary<int, string> slots = new Dictionary<int, string>();
            slots.Add(1, place + " 1");
            slots.Add(2, place + " 2");
            slots.Add(3, place + " 3");
            slots.Add(4, place + " 4");
            slots.Add(5, place + " 5");
            slots.Add(6, place + " 6");
            slots.Add(7, place + " 7");
            slots.Add(8, place + " 8");
            slots.Add(9, place + " 9");
            slots.Add(10, place + " 10");
            slots.Add(11, place + " 11");
            slots.Add(12, place + " 12");
            slots.Add(13, place + " 13");
            slots.Add(14, place + " 14");
            slots.Add(15, place + " 15");
            slots.Add(16, place + " 16");
            slots.Add(17, place + " 17");
            slots.Add(18, place + " 18");
            slots.Add(19, place + " 19");
            slots.Add(20, place + " 20");
            slots.Add(21, place + " 21");
            slots.Add(22, place + " 22");
            slots.Add(23, place + " 23");

            return slots;

        }

        public static void createAdmin(string password)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO [user] (user_name, user_password) VALUES (@username, @password)";
            cmd.Parameters.AddWithValue("@username", "admin");
            cmd.Parameters.AddWithValue("password", hashPass(password));

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }catch (Exception)
            {
                // indexes/keys on user_name
            }

            con.Close();
        }


        public static string dataScrubbing(string txt)
        {

            return txt.ToUpper();
        }

        public static string headGeneratot()
        {
            string decorator = "        CLINIQUE BUCCO-DENTAIRE\n " +
                               "        Email: djunol15@gmail.com\n "+
                               "        Tel: +(509) 3476-7523 /31292117\n "+
                               "        Dr JOACHIM Djunol, DDS\n";
            return decorator;
        }

        public static int ifAdmin(int type)
        {
            int account_type = type;
            return account_type;
        }


        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }

     


    }
}
