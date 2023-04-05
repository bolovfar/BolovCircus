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
        //Кнопка регистрации в окне авторизации
        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
            this.Close();
        }
        

        //Кнопка авторизации
        public void btnAuth_Click(object sender, RoutedEventArgs e)
        {

            var auth = Context.Users.ToList().Where(i => i.Login == txtbLogin.Text && i.Password == psbPassword.Password).FirstOrDefault();
            if (auth != null && txtCatcha.Text == txtCapthcaChek.Text && auth.IDRole == 1) //условие для перехода на окна админа
            {
                IDAuth = auth.IDUser;
                ListOfShowWindow listOfShowWindow = new ListOfShowWindow();
                listOfShowWindow.Show();
                this.Close();
                MessageBox.Show($"Авторизация админа успешно произведена. Здравствуйте, админ {auth.FirstName} {auth.LastName}!");
            }
            else if (auth != null && txtCatcha.Text == txtCapthcaChek.Text && auth.IDRole == 2)//Переход на окна клиента
            {   
                IDAuth = auth.IDUser;
                MyAccountWindow myAccountWindow = new MyAccountWindow();
                myAccountWindow.Show();
                this.Close();
                MessageBox.Show($"Авторизация клиента прошла успешно. Здравствуйте, клиент {auth.FirstName} {auth.LastName}!");
            }
            else //Ошибка авторизации
            {
                MessageBox.Show("ошибка авторизации");
                txtCapthcaChek.Clear();
                getCaptcha();

            }
        }

        private void btnLogoInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
        }
    }
}
