using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LemonDotNetCore.ConsoleApp.Models;
using Dapper;

namespace LemonHM.ConsoleApp.DapperDotNets
{
    public class DapperDotNet
    {
        public void Run()
        {
            //Read();
            //Edit(3);
            //Edit(12);
            //Create("Lin Lin", 47, 789716, "Yangon,Myanmar", 0978952462);
            //Update(2, "Ko Ko", 23, 986316, "Bago,Myanmar", 09229573862);
            Delete(2);
            //Update(1, "hello title", "hello author", "hello content");
            //Delete(1);
        }
        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "LemonHm",
            UserID = "sa",
            Password = "sasasu"
        };

        private void Read()
        {
            string query = @"SELECT [UserID]
      ,[UserName]
      ,[Age]
      ,[NRC]
      ,[Address]
      ,[MobileNo]
  FROM [dbo].[Tbl_User]";
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            List<UserDataModel> lst = db.Query<UserDataModel>(query).ToList();
            foreach (UserDataModel item in lst)
            {
                Console.WriteLine(item.UserID);
                Console.WriteLine(item.UserName);
                Console.WriteLine(item.Age);
                Console.WriteLine(item.NRC);
                Console.WriteLine(item.Address);
                Console.WriteLine(item.MobileNo);
            }
        }
        private void Edit(int id)
               {
            string query = @"SELECT [UserID]
      ,[UserName]
      ,[Age]
      ,[NRC]
      ,[Address]
      ,[MobileNo]
  FROM [dbo].[Tbl_User] where UserID = @UserID";
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
    UserDataModel? item = db.Query<UserDataModel>(
        query, param: new 
        { UserID = id }).FirstOrDefault();
                   if (item is null)
                   {
                       Console.WriteLine("No data is not found");
                       return;
                   }
            Console.WriteLine(item.UserID);
            Console.WriteLine(item.UserName);
            Console.WriteLine(item.Age);
            Console.WriteLine(item.NRC);
            Console.WriteLine(item.Address);
            Console.WriteLine(item.MobileNo);
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

            UserDataModel user = new UserDataModel()
            {
                UserName = UserName,
                Age = Age,
                NRC = NRC,
                Address = Address,
                MobileNo = MobileNo
            };

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, user);

            string message = result > 0 ? "Saving Successful." : "Saving failed";
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

            string query = @"UPDATE [dbo].[Tbl_User]
   SET [UserName] = @UserName
      ,[Age] = @Age
      ,[NRC] = @NRC
      ,[Address] = @Address
      ,[MobileNo] = @MobileNo
 WHERE UserID = @UserID";

            UserDataModel user = new UserDataModel()
            {
                UserID = UserID,
                UserName = UserName,
                Age = Age,
                NRC = NRC,
                Address = Address,
                MobileNo = MobileNo
            };

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, user);

            string message = result > 0 ? "Updating Successful." : "Updating failed";
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


            string query = @"DELETE FROM [dbo].[Tbl_User]
      WHERE UserId = @UserID";

            UserDataModel user = new UserDataModel()
            {
                UserID = UserID,
            };

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, user);

            string message = result > 0 ? "Delete successful" : "Delete failed!!!";
            Console.WriteLine(message);
        }
    }
}
