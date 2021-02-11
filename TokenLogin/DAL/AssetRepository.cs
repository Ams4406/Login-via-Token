using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TokenLogin.Models;

namespace TokenLogin.DAL
{
    public class AssetRepository : IAssetRepository
    {
        private readonly IDbConnection _db;
        public AssetRepository()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public bool InsertAsset(asset OurAsset)
        {
            int rowsAffected = this._db.Execute("INSERT Asset([Name],[Role],[RegistrationDate],[Email],[Password]) VALUES(@Name, @Role,@RegistrationDate, @Email, @Password)",
                                new { Name = OurAsset.Name, Role = OurAsset.Role, RegistrationDate = OurAsset.RegistrationDate, Email = OurAsset.Email, Password = OurAsset.Password });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public asset Login(string Email, string Password)
        {
            return _db.Query<asset>("SELECT [Email],[Password] FROM [Asset] WHERE Email = @Email & Password = @Password",
                new { Email = Email, Password = Password }).FirstOrDefault();
        }

        public asset SearchAssetByID(int ID)
        {
            return _db.Query<asset>("SELECT * FROM [Asset] WHERE ID = @ID",
                new { ID = ID }).SingleOrDefault();
        }

        public asset SearchAssetByName(string Name)
        {
            return _db.Query<asset>("SELECT * FROM [Asset] WHERE Name = @Name",
                new { Name = Name }).SingleOrDefault();
        }

        public List<asset> DisplayAssets()
        {
            return _db.Query<asset>("SELECT * FROM [Asset] ORDER BY ID").ToList();
        }

        public bool UpdateAsset(asset OurAsset)
        {
            int rowsAffected = this._db.Execute(@"UPDATE [Asset] SET [Name] = @Name, [Role] = @Role,[RegistrationDate] = @RegistrationDate, [Email] = @Email, 
                    [Password] = @Password WHERE ID = " + OurAsset.ID, OurAsset);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteAsset(int ID)
        {
            int rowsAffected = this._db.Execute("DELETE FROM [Asset] WHERE ID = @ID", new { ID = ID });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}