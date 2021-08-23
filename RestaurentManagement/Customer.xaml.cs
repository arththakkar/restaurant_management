using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RestaurentManagement.models;

namespace RestaurentManagement
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        public Customer()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt;
            dt = Customerr.all();
            dt_customer.ItemsSource = dt.DefaultView;
        }

        private void btn_customers_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Customer());
        }

        private void btn_menu_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menu());
        }

        private void btn_add_item_Click(object sender, RoutedEventArgs e)
        {
            if (validate_items())
            {
                var first_name = txt_first_name.Text;
                var last_name = txt_last_name.Text;
                var mobile_number = txt_mobile.Text;
                var address = txt_address.Text;
                var city = txt_city.Text;
                var postal_code = txt_postal_code.Text;

                Customerr customer = new Customerr(first_name, last_name, mobile_number, address, city, postal_code);

                DataTable dt = new DataTable();
                dt = customer.create();
                dt_customer.ItemsSource = dt.DefaultView;

                clearItems();
            }
            else
            {
                MessageBox.Show("All fields are compulsory!");
            }
        }

        public void clearItems()
        {
            txt_first_name.Text = "";
            txt_last_name.Text = "";
            txt_mobile.Text = "";
            txt_address.Text = "";
            txt_city.Text = "";
            txt_postal_code.Text = "";
        }

        public bool validate_items()
        {
            if(txt_first_name.Text == "" || txt_last_name.Text == "" || txt_mobile.Text == "" || txt_address.Text == "" || txt_city.Text == "" || txt_postal_code.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
