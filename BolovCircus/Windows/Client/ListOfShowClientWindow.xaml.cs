using BolovCircus.Windows.Info;
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
using BolovCircus.DB;
using BolovCircus.Windows.Info;
using static BolovCircus.ClassHelper.EFClass;


namespace BolovCircus.Windows.Client
{
    /// <summary>
    /// Логика взаимодействия для ListOfShowForClientWindow.xaml
    /// </summary>
    public partial class ListOfShowForClientWindow : Window
    {
        public ListOfShowForClientWindow()
        {
            InitializeComponent();
            LvProductList.ItemsSource = EFClass.Context.Show.ToList();
        }

        private void btnMyAccountWindow_Click(object sender, RoutedEventArgs e)
        {
            MyAccountWindow myAccountWindow = new MyAccountWindow();    
            myAccountWindow.Show();
            this.Close();
        }

        private void btnLogoInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
        }
    }
}
