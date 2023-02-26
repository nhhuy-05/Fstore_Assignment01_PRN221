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
using DataAccess;
using BusinessObject;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceProvider serviceProvider;
        public MainWindow()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
            InitializeComponent();
            Authorize();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IMemberResponsitory), typeof(MemberResponsitory));
            services.AddSingleton<MemberWindow>();
        }
        public void Authorize()
        {
            string user = Application.Current.Properties["User"].ToString();
            if (user=="1")
            {
                btnMember.Visibility = Visibility.Hidden;
            }
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            var memberWindow = serviceProvider.GetService<MemberWindow>();
            memberWindow.Show();
            Close();
        }
    }
}
