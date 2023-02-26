using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            //Config for DependencyInjection (01)
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IMemberResponsitory), typeof(MemberResponsitory));
            services.AddSingleton(typeof(IOrderDetailResponsitory), typeof(OrderDetailResponsitory));
            services.AddSingleton(typeof(IOrderResponsitory), typeof(OrderResponsitory));
            services.AddSingleton(typeof(IProductResponsitory), typeof(ProductResponsitory));
            //services.AddSingleton<Login>();
            services.AddSingleton<MemberWindow>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var login = serviceProvider.GetService<MemberWindow>();
            
            login.Show();
        }
    }
}
