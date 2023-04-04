using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;


using BolovCircus.ClassHelper;
using BolovCircus.DB;
using BolovCircus.Windows.Info;
using static BolovCircus.ClassHelper.EFClass;

namespace BolovCircus.Windows.Admin
{
    /// <summary>
    /// Логика взаимодействия для ListClientWindow.xaml
    /// </summary>
    public partial class ListClientWindow : Window
    {
        public ListClientWindow()
        {
            InitializeComponent();
            dgListOfClientForAdmins.ItemsSource = Context.Users.Where(i => i.IDRole == 2).ToList();
            //getClient();
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Context.SaveChanges();
        }

        private void btnDeleteClientFromAdmin_Click(object sender, RoutedEventArgs e)
        {
            var deletedItem = dgListOfClientForAdmins.SelectedItems.Cast<Users>().ToList();
            if (MessageBox.Show($"Вы уверены?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            { 
                //Не доделано
                    Context.Users.RemoveRange(deletedItem);
                    Context.SaveChanges();
                    dgListOfClientForAdmins.ItemsSource = Context.Users.ToList();
                    MessageBox.Show("Удалено");
            }     
        }

        private void btnListOfStaffWindow_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow listOfStaffWindow = new AdminWindow();
            listOfStaffWindow.Show();
            this.Close(); 
        }

        private void btnListOfShowWindow_Click(object sender, RoutedEventArgs e)
        {
            ListOfShowWindow listOfShowWindow = new ListOfShowWindow();
            listOfShowWindow.Show();
            this.Close();
        }

        private void btnLogoInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
            
        }






        //private void getClient()
        //{
        //    List<Users> clients = new List<Users>();
        //    clients = (List<Users>)Context.Users.Where(i => i.IDRole == 2).ToList();
        //    dgListOfClientForAdmins.ItemsSource = clients;

        //}
    }
}
