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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
            LoadData();
        }

        private void btn_add_category_Click(object sender, RoutedEventArgs e)
        {
            if (validate_category())
            {
                DataTable dt;
                var menu_category = txt_menu_category.Text;
                MenuCategory category = new MenuCategory(0, menu_category);
                dt = category.create();
                dt_menu_category.ItemsSource = dt.DefaultView;
                cmb_menu_category.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = dt.Rows[i]["Menu Category"];
                    item.Tag = dt.Rows[i]["ID"];

                    cmb_menu_category.Items.Add(item);
                }

                clearCategories();
            }
            else
            {
                MessageBox.Show("All fields are compulsory!");
            }
        }

        private void LoadData()
        {
            DataTable dt;
            dt = MenuCategory.all();
            dt_menu_category.ItemsSource = dt.DefaultView;
            cmb_menu_category.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string theValue = dt.Rows[i]["Menu Category"].ToString();
                cmb_menu_category.Items.Add(theValue);
            }

            dt = new DataTable();
            dt = Item.all();
            dt_menu_items.ItemsSource = dt.DefaultView;
        }

        private void btn_add_item_Click(object sender, RoutedEventArgs e)
        {
            if (validate_items())
            {
                var category_name = cmb_menu_category.SelectedItem;
                var item_name = txt_menu_item.Text;

                int category_id = MenuCategory.find_by_category_name(category_name.ToString());

                Item item = new Item(0, category_id, item_name);
                DataTable dt = new DataTable();
                dt = item.create();
                dt_menu_items.ItemsSource = dt.DefaultView;

                clearItems();
            }
            else
            {
                MessageBox.Show("All fields are compulsory!");
            }
        }

        private void clearCategories()
        {
            txt_menu_category.Text = "";
        }

        private void clearItems()
        {
            txt_menu_item.Text = "";
        }

        private bool validate_items()
        {
            if(txt_menu_item.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validate_category()
        {
            if (txt_menu_category.Text == "")
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
