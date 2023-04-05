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



namespace BolovCircus.Windows.Client
{
    /// <summary>
    /// Логика взаимодействия для MyAccountWindow.xaml
    /// </summary>
    public partial class MyAccountWindow : Window
    {
        
        public MyAccountWindow()
        {
            InitializeComponent();
            getInfoAccount();
            getGender();
            getRole();
        }
        private void getGender()
        {
            cmbGenderAccount.ItemsSource = EFClass.Context.Gender.ToList();
            cmbGenderAccount.SelectedIndex = 0;
            cmbGenderAccount.DisplayMemberPath = "Name";
        }

        private void getRole()
        {
            cmbRoleAccount.ItemsSource = EFClass.Context.Role.ToList();
            cmbRoleAccount.SelectedIndex = 0;
            cmbRoleAccount.DisplayMemberPath = "Name";
        }
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            ListOfShowForClientWindow listOfShowForClientWindow = new ListOfShowForClientWindow();
            listOfShowForClientWindow.Show();
            this.Close();
        }

        private void getInfoAccount()
        {
            var auth = Context.Users.ToList().Where(i => i.IDUser == MainWindow.IDAuth).FirstOrDefault();
            txtbFirstNameAccount.Text = auth.FirstName;
            txtbLastNameNameAccount.Text = auth.LastName;
            txtbLoginAccount.Text = auth.Login;
            txtbMailAccount.Text = auth.Mail;
            txtbPhoneAccount.Text = auth.Phone;
        }

        private void btnLogoInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var auth = Context.Users.ToList().Where(i => i.IDUser == MainWindow.IDAuth).FirstOrDefault();
            if (psbNewPasswordAccount.Password != auth.Password && string.IsNullOrEmpty(psbNewPasswordAccount.Password))
            {
                auth.Password = psbNewPasswordAccount.Password;
                Context.SaveChanges();
                MessageBox.Show("Пароль успешно изменен");
            }
            else
            {
                MessageBox.Show("Проль совпадает с прошлым");
            }
           Context.SaveChanges();
            MessageBox.Show("уСПЕШНО СОХРАНЕНО!");
        }
    }
}
