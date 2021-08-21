using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurentManagement.models
{
    class MenuCategory
    {
        int id;
        string category_name;

        public MenuCategory(int id, string category_name)
        {
            this.id = id;
            this.category_name = category_name;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string CategoryName
        {
            get { return this.category_name; }
            set { this.category_name = value; }
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
                sql = "INSERT INTO menuu_category(category_name) VALUES ('" + this.category_name + "') select scope_identity() as Id";
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
                    sql = "SELECT id as ID, category_name as 'Menu Category' from menuu_category";
                    adp = new SqlDataAdapter(sql, con);
                    adp.Fill(dt);
                    con.Close();

                    MessageBox.Show("Category Added Successfully!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
            return dt;
        }

        internal static int find_by_category_name(string category_name)
        {
            int category_id = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string sql = "";

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                sql = "SELECT id from menuu_category where category_name = '" + category_name + "'";
                adp = new SqlDataAdapter(sql, con);
                adp.Fill(dt);
                category_id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }

            return category_id;
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
                sql = "SELECT id as ID, category_name as 'Menu Category' from menuu_category";
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
