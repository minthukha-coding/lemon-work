using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LemonHM.ConsoleApp.AdoDotNets
{
    public class AdoDotNet
    {
        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(12);
            //Create("LawonEain",17,346316,"Taunggyi,Shan,Myanmar",09629573862);
            //Update(1,"Lawon Eain",17,346316,"Taunggyi,Shan,Myanmar",09629573862);
            //Delete(1);
            // Update(1, "hello title", "hello author", "hello content");
            //Delete(1);
        }

        private void Read() {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "LemonHm",
                UserID = "sa",
                Password = "sasasu"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection is open");

            string query = @"SELECT [UserID]
      ,[UserName]
      ,[Age]
      ,[NRC]
      ,[Address]
      ,[MobileNo]
  FROM [dbo].[Tbl_User]";

            SqlCommand command = new SqlCommand (query,connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Id => " + dr["UserID"]);
                Console.WriteLine($"Title => {dr["UserName"]}");
                Console.WriteLine("Author => " + dr["Age"]);
                Console.WriteLine("Content => " + dr["NRC"]);
                Console.WriteLine("Content => " + dr["Address"]);
                Console.WriteLine("Content => " + dr["MobileNo"]);
                Console.WriteLine("_________________");
            }
        }  
        private void Edit(int Id) {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "LemonHm",
                UserID = "sa",
                Password = "sasasu"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"SELECT [UserID]
      ,[UserName]
      ,[Age]
      ,[NRC]
      ,[Address]
      ,[MobileNo]
  FROM [dbo].[Tbl_User] where UserID = @UserID";

            SqlCommand command = new SqlCommand (query,connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            command.Parameters.AddWithValue("@UserID", Id);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            if (dt.Rows.Count == 0 ) {
                Console.WriteLine("No data is not found!!");
                return;
            }
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Id => " + dr["UserID"]);
                Console.WriteLine($"Title => {dr["UserName"]}");
                Console.WriteLine("Author => " + dr["Age"]);
                Console.WriteLine("Content => " + dr["NRC"]);
                Console.WriteLine("Content => " + dr["Address"]);
                Console.WriteLine("Content => " + dr["MobileNo"]);
                Console.WriteLine("_________________");
            }
        }
        private void Create(string UserName, int Age, long NRC, string Address, long MobileNo)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "LemonHm",
                UserID = "sa",
                Password = "sasasu"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"
INSERT INTO [dbo].[Tbl_User]
           ([UserName]
           ,[Age]
           ,[NRC]
           ,[Address]
           ,[MobileNo])
     VALUES
           (@UserName
           ,@Age
           ,@NRC
           ,@Address
           ,@MobileNo)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Age", Age);
            command.Parameters.AddWithValue("@NRC", NRC);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@MobileNo", MobileNo);
            //try { int reault = command.ExecuteNonQuery(); } catch(Exception ex) {
            //    Console.WriteLine(ex.Message);
            //}
            int result = command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Saving!!");
            string message = result > 0 ? "Saving successful" : "Saving failed!!!";
            Console.WriteLine(result);
            Console.WriteLine(message);
        }       
        private void Update(int UserID, string UserName, int Age, long NRC, string Address, long MobileNo)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "LemonHm",
                UserID = "sa",
                Password = "sasasu"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"UPDATE [dbo].[Tbl_User]
   SET [UserName] = @UserName
      ,[Age] = @Age
      ,[NRC] = @NRC
      ,[Address] = @Address
      ,[MobileNo] = @MobileNo
 WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Age", Age);
            command.Parameters.AddWithValue("@NRC", NRC);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@MobileNo", MobileNo);
            //try { int reault = command.ExecuteNonQuery(); } catch(Exception ex) {
            //    Console.WriteLine(ex.Message);
            //}
            int result = command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Saving!!");
            string message = result > 0 ? "Updating successful" : "Updating failed!!!";
            Console.WriteLine(result);
            Console.WriteLine(message);
        }
        private void Delete(int UserID)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "LemonHm",
                UserID = "sa",
                Password = "sasasu"
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            string query = @"DELETE FROM [dbo].[Tbl_User]
      WHERE UserId = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            int result = command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Saving!!");
            string message = result > 0 ? "Delete successful" : "Delete failed!!!";
            Console.WriteLine(result);
            Console.WriteLine(message);
        }
    }
}