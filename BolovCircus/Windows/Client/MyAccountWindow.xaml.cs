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
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            ListOfShowForClientWindow listOfShowForClientWindow = new ListOfShowForClientWindow();
            listOfShowForClientWindow.Show();
            this.Close();
            
        }

        private void getInfoAccount()
        {
           

        }
    }
}
