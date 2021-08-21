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
    class Item
    {
        int id;
        int category_id;
        string item_name;

        public Item(int id, int category_id, string item_name)
        {
            this.id = id;
            this.category_id = category_id;
            this.item_name = item_name;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int CategoryId
        {
            get { return this.category_id; }
            set { this.category_id = value; }
        }

        public string ItemName
        {
            get { return this.item_name; }
            set { this.item_name = value; }
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
                sql = "INSERT INTO item(category_id, item_name) VALUES (" + this.category_id + ", '" + this.item_name + "') select scope_identity() as Id";
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
                    sql = "SELECT i.id as ID, item_name as 'Menu Item', category_name as 'Menu Category' from item i left join menuu_category ca on i.category_id = ca.id";
                    adp = new SqlDataAdapter(sql, con);
                    adp.Fill(dt);
                    con.Close();

                    MessageBox.Show("Menu Item Added Successfully!");
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
                sql = "SELECT i.id as ID, item_name as 'Menu Item', category_name as 'Menu Category' from item i left join menuu_category ca on i.category_id = ca.id";
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
