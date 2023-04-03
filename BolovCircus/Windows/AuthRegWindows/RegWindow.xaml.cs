using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using BolovCircus.Windows.Info;
using static BolovCircus.ClassHelper.EFClass;

namespace BolovCircus.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
            getUserRoleReg();
            getUserGender();
        }



        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            // валидация 
            if (string.IsNullOrWhiteSpace(txtbLoginReg.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
                return;
            }

            //Int32.TryParse(TbPhone.Text, out _);

            // проверка на уникальность 
            var authUser = EFClass.Context.Users.ToList()
                .Where(i => i.Login == txtbLoginReg.Text).FirstOrDefault();
            
            if (authUser != null)
            {
                MessageBox.Show("логин занят");
                return;
            }

            // добавление в БД
            if (psbPasswordReg.Password == psbPasswordReg2.Password && dpBirthday.SelectedDate.Value <= DateTime.Now)
            {
                DB.Users users = new DB.Users();
                users.IDGender = (cmbGenderReg.SelectedItem as DB.Gender).IDGender;
                users.Login = txtbLoginReg.Text;
                users.Password = psbPasswordReg.Password;
                users.FirstName = txtbFirstNameReg.Text;
                users.LastName = txtbLastNameNameReg.Text;
                users.Birthday = dpBirthday.SelectedDate.Value;
                users.Phone = txtbPhoneReg.Text;
                users.Mail = txtbMailReg.Text;
                users.Role = (cmbRoleReg.SelectedItem as DB.Role);

                EFClass.Context.Users.Add(users);

                EFClass.Context.SaveChanges();

                MessageBox.Show($"Регистрация пользователя {txtbLoginReg.Text} с должностью {users.Role} произведена успешна");
            }
            else MessageBox.Show("Ошибква в заполнении данных");
            
        }

        //получение выбора гендера и роли
        public void getUserRoleReg()
        {
            cmbRoleReg.ItemsSource = EFClass.Context.Role.ToList();
            cmbRoleReg.SelectedIndex = 0;
            cmbRoleReg.DisplayMemberPath = "Name";
        }

        public void getUserGender()
        {
            cmbGenderReg.ItemsSource = EFClass.Context.Gender.ToList();
            cmbGenderReg.SelectedIndex = 0;
            cmbGenderReg.DisplayMemberPath = "Name";
        }

        //Декор внесения данный
        private void txtbLoginReg_GotFocus(object sender, RoutedEventArgs e)
        {
            txtbLoginReg.Clear();
        }

        private void txtbLoginReg_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtbLoginReg == null || txtbLoginReg.Text == "")
            {
                txtbLoginReg.Text = "Введите логин";
            }
        }

        private void txtbFirstNameReg_GotFocus(object sender, RoutedEventArgs e)
        {
            txtbFirstNameReg.Clear();
        }

        private void txtbFirstNameReg_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtbFirstNameReg == null || txtbFirstNameReg.Text == "")
            {
                txtbFirstNameReg.Text = "Введите имя";
            }
        }

        private void txtbLastNameNameReg_GotFocus(object sender, RoutedEventArgs e)
        {
            txtbLastNameNameReg.Clear();
        }

        private void txtbLastNameNameReg_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtbLastNameNameReg == null || txtbLastNameNameReg.Text == "")
            {
                txtbLastNameNameReg.Text = "Введите фамилию";
            }
        }

        private void txtbMailReg_GotFocus(object sender, RoutedEventArgs e)
        {
            txtbMailReg.Clear();
        }

        private void txtbMailReg_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtbMailReg == null || txtbMailReg.Text == "")
            {
                txtbMailReg.Text = "Введите почту";
            }
        }

        private void txtbPhoneReg_GotFocus(object sender, RoutedEventArgs e)
        {
            txtbPhoneReg.Clear();
        }

        private void txtbPhoneReg_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtbPhoneReg == null || txtbPhoneReg.Text == "")
            {
                txtbPhoneReg.Text = "Введите номер телефона";
            }
        }
        //Кнопка информации о цирке
        private void btnLogoInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
            this.Close();
        }
    }
}
