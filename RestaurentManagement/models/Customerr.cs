using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RestaurentManagement.models;

namespace RestaurentManagement.models
{
    class Customerr : User
    {
        private int user_id;
        private string address;
        private string city;
        private string postal_code;

        public Customerr(string first_name, string last_name, string mobile_number, string address, string city, string postal_code) : base(first_name, last_name, mobile_number)
        {
            this.address = address;
            this.city = city;
            this.postal_code = postal_code;
            this.postal_code = postal_code;
        }

        public int UserId
        {
            get { return this.user_id; }
            set { this.user_id = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }

        public string PostalCode
        {
            get { return this.postal_code; }
            set { this.postal_code = value; }
        }

        public DataTable create()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string sql = "";

            adp = new SqlDataAdapter();
            dt = new DataTable();

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                sql = "INSERT INTO [User](first_name, last_name, mobile_number) VALUES ('" + this.FirstName + "', '" + this.LastName + "', '" + this.MobileNumber + "') select scope_identity() as Id";
                adp = new SqlDataAdapter(sql, con);
                adp.Fill(dt);
                int result = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                con.Close();
                if (result > 0)
                {
                    adp = new SqlDataAdapter();
                    dt = new DataTable();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    sql = "INSERT INTO Customerr(user_id, address, city, postal_code) VALUES (" + result + ", '" + this.Address + "', '" + this.City + "', '" + this.PostalCode + "')";
                    adp = new SqlDataAdapter(sql, con);
                    adp.Fill(dt);
                    con.Close();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    sql = "SELECT first_name as 'First Name', last_name as 'Last Name', mobile_number as 'Mobile Number', address as Address, city as City, postal_code as 'Postal Code' from Customerr c left join [User] u on u.id = c.user_id";
                    adp = new SqlDataAdapter(sql, con);
                    adp.Fill(dt);
                    con.Close();

                    MessageBox.Show("Customer Added Successfully!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
            return dt;
        }

        public static DataTable all()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string sql = "";

            adp = new SqlDataAdapter();
            dt = new DataTable();

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                sql = "SELECT first_name as 'First Name', last_name as 'Last Name', mobile_number as 'Mobile Number', address as Address, city as City, postal_code as 'Postal Code' from Customerr c left join [User] u on u.id = c.user_id";
                adp = new SqlDataAdapter(sql, con);
                adp.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
            return dt;
        }
    }
}
