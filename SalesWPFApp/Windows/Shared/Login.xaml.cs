using BusinessObject;
using DataAccess.Repository;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        IMemberResponsitory memberResponsitory;
        public Login(IMemberResponsitory mResponsitory)
        {
            InitializeComponent();
            memberResponsitory = mResponsitory;
        }
       

        public void LoginBtn(object sender, RoutedEventArgs e)
        {
            Member member = memberResponsitory.Login(txtEmail.Text, txtPass.Password);
            if (member != null)
            {
                Application.Current.Properties["User"] = 1;
                MainWindow objMainWindow = new MainWindow();           
                objMainWindow.Show();
                Close();                  
            }
            else if (txtEmail.Text == "admin@fstore.com" && txtPass.Password == "admin@@")
            {
                Application.Current.Properties["User"] = 0;
                MainWindow objMainWindow = new MainWindow();
                objMainWindow.Show();
                Close();              
            }
            else
            {
                MessageBox.Show("Your account doesn't exist", "Warning", 
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.Yes);
            }
        }
    }
}
