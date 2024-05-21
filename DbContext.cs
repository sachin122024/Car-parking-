using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Carparking1.Models
{
    public class DbContext
    {
        string connection = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;




        public List<register> Getuser()
        {
            List<register> userList = new List<register>();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("userData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                register reg = new register();
                reg.Id = Convert.ToInt32(dr.GetValue(0).ToString());
                reg.FirstName = dr.GetValue(1).ToString();
                
                reg.LastName = dr.GetValue(2).ToString();
                reg.Email = dr.GetValue(3).ToString();
                reg.Mobile = Convert.ToInt32(dr.GetValue(4).ToString());
                reg.Vehicalno = dr.GetValue(5).ToString();
                userList.Add(reg);
            }
            con.Close();

            return userList;
            
        }


        public bool insertRegister(register reg)
        {

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("userInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", reg.FirstName);
            cmd.Parameters.AddWithValue("@LastName", reg.LastName);
            cmd.Parameters.AddWithValue("@Email", reg.Email);
            cmd.Parameters.AddWithValue("@Mobile", reg.Mobile);
            cmd.Parameters.AddWithValue("@vehicalNo", reg.Vehicalno);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // update
        public bool userUpdate(register reg)
        {

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("userUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", reg.Id);
            cmd.Parameters.AddWithValue("@FirstName", reg.FirstName);
            cmd.Parameters.AddWithValue("@LastName", reg.LastName);
            cmd.Parameters.AddWithValue("@Email", reg.Email);
            cmd.Parameters.AddWithValue("@Mobile", reg.Mobile);
            cmd.Parameters.AddWithValue("@vehicalNo", reg.Vehicalno);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete
        public bool userDelete(register reg)
        {

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("userDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", reg.Id);
          
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //    Contact     Us-------
        public bool Contact(Contact cont)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("userContact", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", cont.Name);
            cmd.Parameters.AddWithValue("@Email", cont.Email);
            cmd.Parameters.AddWithValue("@Phone", cont.Phone);
            cmd.Parameters.AddWithValue("Message", cont.Message);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a>0)
            {
                return true;
            }
            else
            {
                return false;
            }

           }






    }


}