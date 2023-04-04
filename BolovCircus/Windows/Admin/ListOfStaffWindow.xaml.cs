using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            dgListOfStaffForAdmin.ItemsSource = Context.Users.Where(i => i.IDRole == 1).ToList();
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Context.SaveChanges();
        }

        private void btnDeleteClientFromAdmin_Click(object sender, RoutedEventArgs e)
        {
            //Также не доделанно из-за отсутствия возможности изменения БД
            var deletedItem = dgListOfStaffForAdmin.SelectedItems.Cast<Users>().ToList();
            if (MessageBox.Show($"Вы уверены?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //Не доделано
                Context.Users.RemoveRange(deletedItem);
                Context.SaveChanges();
                dgListOfStaffForAdmin.ItemsSource = Context.Users.ToList();
                MessageBox.Show("Удалено");
            }
        }

        private void btnListOfShowWindow_Click(object sender, RoutedEventArgs e)
        {
            ListOfShowWindow listOfShowWindow = new ListOfShowWindow();
            listOfShowWindow.Show();
            this.Close();
        }

        private void btnListOfClientWindow_Click(object sender, RoutedEventArgs e)
        {
            ListClientWindow listOfClientWindow = new ListClientWindow();
            listOfClientWindow.Show();
            this.Close();
        }

        private void btnLogoInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
        }
    }
}
