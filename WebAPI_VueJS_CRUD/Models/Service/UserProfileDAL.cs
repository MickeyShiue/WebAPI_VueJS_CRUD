using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_VueJS_CRUD.Models;
using Dapper;
using System.Data.SqlClient;

namespace WebAPI_VueJS_CRUD.Models.Service
{
    public class UserProfileDAL
    {
        string Connstr = System.Configuration.ConfigurationManager.ConnectionStrings["kahapConnectionString"].ConnectionString;

        public IEnumerable<UserProfile> GetDataList()
        {
            IEnumerable<UserProfile> Data;
            using (var conn = new SqlConnection(Connstr))
            {
                conn.Open();
                Data = conn.Query<UserProfile>("SELECT Email, Name, Gender, Convert(varchar,Birthday,111) AS Birthday, PhoneNum, Address FROM UserProfile").AsEnumerable();           
            }
            return Data;
        }

        public UserProfile GetData(string Email)
        {
            UserProfile Data;
            using (var conn = new SqlConnection(Connstr))
            {
                conn.Open();
                Data = conn.Query<UserProfile>("SELECT Email, Name, Gender, Convert(varchar,Birthday,111) AS Birthday, PhoneNum, Address FROM UserProfile Where Email=@Email", new { @Email = Email }).SingleOrDefault();
            }
            return Data;
        }

        public void Add(UserProfile user)
        {
            using (var conn = new SqlConnection(Connstr))
            {
                conn.Open();
                conn.Execute("Insert Into UserProfile(Email, Name, Gender, Birthday, PhoneNum, Address) Values(@Email, @Name, @Gender, @Birthday, @PhoneNum, @Address)", user);
            }
        }

        public void Update(UserProfile user)
        {
            using (var conn = new SqlConnection(Connstr))
            {
                conn.Open();
                conn.Execute("Update UserProfile Set Name=@Name,Gender=@Gender,Birthday=@Birthday,PhoneNum=@PhoneNum,Address=@Address Where Email=@Email", user);
            }
        }

        public void Delete(string Email)
        {
            using (var conn = new SqlConnection(Connstr))
            {
                conn.Open();
                conn.Execute("Delete UserProfile Where Email=@Email", new { @Email= Email });
            }
        }
    }
}