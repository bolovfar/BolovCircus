using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



using BolovCircus.ClassHelper;
using BolovCircus.DB;
using BolovCircus.Windows.Info;
using static BolovCircus.ClassHelper.EFClass;



namespace BolovCircus.Windows.Admin
{
    /// <summary>
    /// Логика взаимодействия для ListOfShowWindow.xaml
    /// </summary>
    public partial class ListOfShowWindow : Window
    {
        public ListOfShowWindow()
        {
            InitializeComponent();
            LvProductList.ItemsSource = Context.Show.ToList();
        }

        private void btnListOfStaffWindow_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow listOfAdminWindow = new AdminWindow();
            listOfAdminWindow.Show();
            this.Close();
        }

        private void btnListOfClientWindow_Click(object sender, RoutedEventArgs e)
        {
            ListClientWindow listClientWindow = new ListClientWindow();
            listClientWindow.Show();
            this.Close();
        }

        private void btnLogoInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
        }
    }
}
