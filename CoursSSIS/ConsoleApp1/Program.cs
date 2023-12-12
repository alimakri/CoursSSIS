using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uri = "https://restcountries.com/v3.1/all";
            List<Pays> listePays = null;
            using (WebClient client = new WebClient { Encoding = Encoding.UTF8 })
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                try
                {
                    var resultatString = client.DownloadString(uri);
                     listePays = JsonConvert.DeserializeObject<List<Pays>>(resultatString);
                }
                catch (Exception ex)
                {
                    
                }
            }
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=true";
            cnx.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert Pays (nom) values";
            foreach (var pay in listePays)
            {
                cmd.CommandText += $"('{pay.Name.Common}'),";
            }
            cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
            Console.WriteLine(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {  }
        }
    }
    public class Pays
    {
        public PaysName Name;
    }
    public class PaysName
    {
        public string Common;
    }

}
