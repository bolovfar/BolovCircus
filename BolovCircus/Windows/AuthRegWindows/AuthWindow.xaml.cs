using BolovCircus.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BolovCircus.ClassHelper;
using static BolovCircus.ClassHelper.EFClass;
using BolovCircus.Windows.Client;
using BolovCircus.Windows.Admin;
using System.Windows.Media.Animation;
using BolovCircus.Windows.Info;

namespace BolovCircus
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public static int IDAuth;
        public MainWindow()
        {
            
            InitializeComponent();
            getUserRole();
            getCaptcha();
        }


        //Капча
        public void getCaptcha()
        {
            string simb = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            string txt = "";
            Random rnd = new Random();
            for (int i = 0; i < 6; ++i)
            {
                txt += simb[rnd.Next(simb.Length)];
            }
            txtCatcha.Text = txt;
        }


        //Отображение
        private void txtbLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            txtbLogin.Clear();
        }

        private void txtbLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtbLogin == null || txtbLogin.Text == "")
            {
                txtbLogin.Text = "Логин"; 
            }
            
        }


        //Получение роли пользователя для упрощения дальнейшей навигации
        public void getUserRole()
        {
            cmbUserRole.ItemsSource = Context.Role.ToList();
            cmbUserRole.SelectedIndex = 0;
            cmbUserRole.DisplayMemberPath = "Name";
        }
        //Кнопка регистрации в окне авторизации
        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
            this.Close();
        }
        

        //Кнопка авторизации
        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {

            var auth = Context.Users.ToList().Where(i => i.Login == txtbLogin.Text && i.Password == psbPassword.Password && i.IDRole == cmbUserRole.SelectedIndex+1).FirstOrDefault();
            if (auth != null && auth.IDRole == 1 && txtCatcha.Text == txtCapthcaChek.Text) //условие для перехода на окна 
            {
                
                if (auth.IDRole == 1) 
                {//Переход на окна админа
                    IDAuth = auth.IDUser;
                    ListOfShowWindow listOfShowWindow = new ListOfShowWindow();
                    listOfShowWindow.Show();
                    this.Close();
                    MessageBox.Show($"Авторизация админа успешно произведена. Здравствуйте, {auth.FirstName} {auth.LastName}!");
                }
                else
                {   //Переход на окна клиента
                    IDAuth = auth.IDUser;
                    MyAccountWindow myAccountWindow = new MyAccountWindow();
                    myAccountWindow.Show();
                    this.Close();
                    MessageBox.Show($"Авторизация клиента прошла успешно. Здравствуйте, {auth.FirstName} {auth.LastName}!") ;
                }
                
                
            }
            else //Ошибка авторизации
            {
                MessageBox.Show("ошибка авторизации");
                getCaptcha();
                txtCapthcaChek.Clear();
            }
        }

        private void btnLogoInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
            this.Close();
        }
    }
}
